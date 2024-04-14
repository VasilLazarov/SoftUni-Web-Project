﻿using LaLigaFans.Core.Models.Team;

namespace LaLigaFans.Core.Contracts.TeamContracts
{
    public interface ITeamService
    {
        Task<TeamsQueryServiceModel> AllAsync(
            int currentPage = 1,
            int housesPerPage = 1);

        Task<bool> IsFollowedByUserWithIdAsync(int teamId, string userId);

        Task<TeamDetailsServiceModel> TeamDetailsByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task FollowAsync(int teamId, string userId);

        Task UnfollowAsync(int teamId, string userId);

        Task<TeamsQueryServiceModel> FollowedAsync(
            string userId,
            int currentPage = 1,
            int housesPerPage = 1);
    }
}
