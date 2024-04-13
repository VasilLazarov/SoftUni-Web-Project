using LaLigaFans.Core.Models.Player;

namespace LaLigaFans.Core.Contracts.PlayerContracts
{
    public interface IPlayerService
    {
        Task<PlayersQueryServiceModel> AllPlayersByTeamIdAsync(
            int id,
            int currentPage = 1,
            int housesPerPage = 1);
    }
}
