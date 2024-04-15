using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
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

        private readonly ITeamService teamService;

        public PlayerController(
            IPlayerService _playerService,
            ITeamService _teamService)
        {
            playerService = _playerService;
            teamService = _teamService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id, [FromQuery] AllPlayersQueryModel query)
        {
            if (await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }   

            var queryResult = await playerService.AllPlayersByTeamIdAsync(
                id,
                query.CurrentPage,
                AllPlayersQueryModel.PlayersPerPage);

            query.TotalPlayersCount = queryResult.TotalPlayersCount;
            query.Players = queryResult.Players;
            if(query.Players.Count() > 0)
            {
                query.TeamName = query.Players.First().TeamName;
            }

            return View(query);
        }
    }
}
