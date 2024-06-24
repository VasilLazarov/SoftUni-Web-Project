using LaLigaFans.Core.Models.Player;
using LaLigaFans.Core.Models.Team;

namespace LaLigaFans.Core.Contracts.PlayerContracts
{
    public interface IPlayerService
    {
        Task<PlayersQueryServiceModel> AllPlayersByTeamIdAsync(
            int id,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<bool> ExistsAsync(int id);

        Task<int> CreateAsync(TeamPlayerAddFormModel model);

        Task<PlayerEditFormModel?> GetPlayerEditFormModelByIdAsync(int playerId);

        Task EditAsync(int playerId, PlayerEditFormModel model);

        Task DeleteAsync(int playerId);

        Task<PlayerDeleteServiceModel?> GetPlayerDeleteServiceModelByIdAsync(int playerId);

        Task<PlayersQueryServiceModel> DeletedPlayersAsync(
            int currentPage = 1,
            int housesPerPage = 1);

        Task<bool> ExistsDeletedAsync(int id);

        Task<PlayerDeleteServiceModel?> GetPlayerReturnServiceModelByIdAsync(int playerId);

        Task ReturnAsync(int playerId);


    }
}
