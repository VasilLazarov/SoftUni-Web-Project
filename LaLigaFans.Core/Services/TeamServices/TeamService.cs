using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var team = await repository.GetByIdAsync<Team>(teamId);

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


    }
}
