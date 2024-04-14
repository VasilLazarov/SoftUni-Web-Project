using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Core.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repository;

        public TeamService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<TeamsQueryServiceModel> AllAsync(
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var teams = await repository.AllReadOnly<Team>()
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToTeamServiceModel()
                .ToListAsync();

            var totalTeams = await repository.AllReadOnly<Team>().CountAsync();

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
            var team = await repository.All<Team>()
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
                .Where(t => t.Followers.Any(ut => ut.ApplicationUserId == userId))
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToTeamServiceModel()
                .ToListAsync();

            var totalTeams = await repository.AllReadOnly<Team>()
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
            if(!await UploadImage(model.ImageLogo, folderName))
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

        private async Task<bool> UploadImage(IFormFile image, string folderName)
        {
            bool result = false;

            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "img", folderName);

            string fileName = Path.Combine(path, image.FileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
                result = true;
            }

            return result;
        }



    }
}
