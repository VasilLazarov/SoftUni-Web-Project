using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Core.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repository;
        private readonly IUploadService uploadService;

        public TeamService(IRepository _repository,
            IUploadService _uploadService)
        {
            repository = _repository;
            uploadService = _uploadService;
        }

        public async Task<TeamsQueryServiceModel> AllAsync(
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var teams = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToTeamServiceModel()
                .ToListAsync();

            var totalTeams = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .CountAsync();

            var teamsAndCount = new TeamsQueryServiceModel()
            {
                Teams = teams,
                TotalTeamsCount = totalTeams
            };

            return teamsAndCount;
        }

        public async Task<bool> IsFollowedByUserWithIdAsync(int teamId, string userId)
        {
            bool result = false;
            var team = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == teamId)
                .Include(t => t.Followers)
                .FirstOrDefaultAsync();

            if (team != null)
            {
                result = team.Followers.Any(f => f.ApplicationUserId == userId);
            }

            return result;
        }

        public async Task<TeamDetailsServiceModel> TeamDetailsByIdAsync(int id)
        {
            var teamWithDetails = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == id)
                .Select(t => new TeamDetailsServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    CoachName = t.CoachName,
                    FoundedYear = t.FoundedYear,
                    LogoUrl = t.LogoUrl,
                    Information = t.Information
                })
                .FirstAsync();

            return teamWithDetails;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool result = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .AnyAsync(t => t.Id == id);

            return result;
        }

        public async Task FollowAsync(int teamId, string userId)
        {

            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.FollowedTeams)
                .FirstOrDefaultAsync();

            if(user != null)
            {
                var appUserTeam = new ApplicationUserTeam()
                {
                    TeamId = teamId
                };

                user.FollowedTeams.Add(appUserTeam);
                await repository.SaveChangesAsync();

            }

        }
        
        public async Task UnfollowAsync(int teamId, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.FollowedTeams)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var removeItem = user.FollowedTeams
                    .Where(ut => ut.TeamId == teamId)
                    .FirstOrDefault();
                if(removeItem != null)
                {
                    user.FollowedTeams.Remove(removeItem);
                    await repository.SaveChangesAsync();
                }
            }

        }

        public async Task<TeamsQueryServiceModel> FollowedAsync(
            string userId,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var teams = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Followers.Any(ut => ut.ApplicationUserId == userId))
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToTeamServiceModel()
                .ToListAsync();

            var totalTeams = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Followers.Any(ut => ut.ApplicationUserId == userId))
                .CountAsync();

            var teamsAndCount = new TeamsQueryServiceModel()
            {
                Teams = teams,
                TotalTeamsCount = totalTeams
            };

            return teamsAndCount;
        }

        public async Task<int> CreateAsync(TeamAddFormModel model)
        {
            string logoUrl = model.ImageLogo.FileName;
            string folderName = "teams";
            if(!await uploadService.UploadImage(model.ImageLogo, folderName))
            {
                logoUrl = "Default.png";
            }

            var team = new Team()
            {
                Name = model.Name,
                CoachName = model.CoachName,
                FoundedYear = model.FoundedYear,
                Information = model.Information,
                LogoUrl = logoUrl
            };

            await repository.AddAsync(team);
            await repository.SaveChangesAsync();

            return team.Id;
        }

        public async Task EditAsync(int teamId, TeamEditFormModel model)
        {
            var team = await repository.GetByIdAsync<Team>(teamId);

            if(team != null)
            {
                team.Name = model.Name;
                team.CoachName = model.CoachName;
                team.FoundedYear = model.FoundedYear;
                team.Information = model.Information;

                if(model.ImageLogo != null)
                {
                    string logoUrl = model.ImageLogo.FileName;
                    string folderName = "teams";
                    if (!await uploadService.UploadImage(model.ImageLogo, folderName))
                    {
                        logoUrl = "Default.png";
                    }
                    team.LogoUrl = logoUrl;
                }

                await repository.SaveChangesAsync();
            }

        }

        public async Task<TeamEditFormModel?> GetTeamEditFormModelByIdAsync(int teamId)
        {
            var teamModel = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == teamId)
                .Select(t => new TeamEditFormModel()
                {
                    Name = t.Name,
                    FoundedYear = t.FoundedYear,
                    CoachName = t.CoachName,
                    Information = t.Information
                })
                .FirstOrDefaultAsync();

            return teamModel;
        }

        public async Task<IEnumerable<TeamBasicServiceModel>> GetTeamIdsAndNames()
        {
            return await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Select(t => new TeamBasicServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<string>> AllTeamNamesAsync()
        {
            var allTeamNames = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Select(t => t.Name)
                .Distinct()
                .ToListAsync();

            return allTeamNames;
        }

        public async Task DeleteAsync(int teamId)
        {
            var team = await repository.All<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == teamId)
                .Include(t => t.Players)
                .Include(t => t.News)
                .Include(t => t.Products)
                .FirstOrDefaultAsync();

            if(team != null)
            {
                team.IsActive = false;
                foreach (var p in team.Players)
                {
                    p.IsActive = false;
                }
                foreach (var n in team.News)
                {
                    n.IsActive = false;
                }
                foreach (var p in team.Products)
                {
                    p.IsActive = false;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<TeamDeleteServiceModel?> GetTeamDeleteServiceModelByIdAsync(int teamId)
        {
            var teamModel = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == teamId)
                .Select(t => new TeamDeleteServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    CoachName = t.CoachName,
                    FoundedYear = t.FoundedYear,
                    Information = t.Information,
                    LogoUrl = t.LogoUrl
                })
                .FirstOrDefaultAsync();

            return teamModel;
        }

        public async Task<TeamDeleteServiceModel?> GetTeamReturnServiceModelByIdAsync(int teamId)
        {
            var teamModel = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .Where(t => t.Id == teamId)
                .Select(t => new TeamDeleteServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    CoachName = t.CoachName,
                    FoundedYear = t.FoundedYear,
                    Information = t.Information,
                    LogoUrl = t.LogoUrl
                })
                .FirstOrDefaultAsync();

            return teamModel;
        }


    }
}
