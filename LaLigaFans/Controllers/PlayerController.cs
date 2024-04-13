using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Models.Player;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Core.Services.TeamServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService _playerService)
        {
            playerService = _playerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id, [FromQuery] AllPlayersQueryModel query)
        {
            var queryResult = await playerService.AllPlayersByTeamIdAsync(
                id,
                query.CurrentPage,
                AllPlayersQueryModel.PlayersPerPage);

            query.TotalPlayersCount = queryResult.TotalPlayersCount;
            query.Players = queryResult.Players;
            query.TeamName = query.Players.First().TeamName;

            return View(query);
        }
    }
}
