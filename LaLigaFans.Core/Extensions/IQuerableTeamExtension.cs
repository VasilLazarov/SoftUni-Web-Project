using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableTeamExtension
    {
        public static IQueryable<TeamServiceModel> ProjectToTeamServiceModel(this IQueryable<Team> teams)
        {
            var projectTeams = teams
                .Select(t => new TeamServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    FoundedYear = t.FoundedYear,
                    LogoUrl = t.LogoUrl,
                    CoachName = t.CoachName,
                });

            return projectTeams;
        }
    }
}
