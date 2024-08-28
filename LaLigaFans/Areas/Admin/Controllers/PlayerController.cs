using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Player;
using LaLigaFans.Core.Models.Team;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LaLigaFans.Core.Constants.MessageConstants;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class PlayerController : AdminBaseController
    {
        private readonly IPlayerService playerService;
        private readonly ITeamService teamService;

        public PlayerController(IPlayerService _playerService,
            ITeamService _teamService)
        {
            playerService = _playerService;
            teamService = _teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new TeamPlayerAddFormModel()
            {
                Teams = await teamService.GetTeamIdsAndNames()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeamPlayerAddFormModel model)
        {
            if(await teamService.ExistsAsync(model.TeamId) == false)
            {
                ModelState.AddModelError(nameof(model.TeamId), TeamErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetTeamIdsAndNames();
                return View(model);
            }

            int newPlayerTeamId = await playerService.CreateAsync(model);

            return RedirectToAction("All", "Player", new { area = "", id = newPlayerTeamId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await playerService.ExistsAsync(id) == false && await playerService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            var playerModel = await playerService.GetPlayerEditFormModelByIdAsync(id);
            
            if(playerModel != null)
            {
                playerModel.Teams = await teamService.GetTeamIdsAndNames();
            }

            return View(playerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlayerEditFormModel model)
        {
            if (await playerService.ExistsAsync(id) == false && await playerService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            if (await teamService.ExistsAsync(model.TeamId) == false)
            {
                ModelState.AddModelError(nameof(model.TeamId), TeamErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetTeamIdsAndNames();
                return View(model);
            }

            await playerService.EditAsync(id, model);

            return RedirectToAction("All", "Player", new { area = "", id = model.TeamId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await playerService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var playerModel = await playerService.GetPlayerDeleteServiceModelByIdAsync(id);

            return View(playerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int teamId, PlayerDeleteServiceModel model)
        {
            if (await playerService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await playerService.DeleteAsync(model.Id);

            return RedirectToAction("All", "Player", new { area = "", id = teamId });
        }

        [HttpGet]
        public async Task<IActionResult> AllDeleted([FromQuery] AllPlayersQueryModel query)
        {

            var queryResult = await playerService.DeletedPlayersAsync(
                query.CurrentPage,
                AllPlayersQueryModel.PlayersPerPage);

            query.TotalPlayersCount = queryResult.TotalPlayersCount;
            query.Players = queryResult.Players;
            if (query.Players.Count() > 0)
            {
                query.TeamName = query.Players.First().TeamName;
            }

            return View(query);
        }


        [HttpGet]
        public async Task<IActionResult> Return(int id)
        {
            if (await playerService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            if(await teamService.ExistsPlayerTeamAsync(id) == false)
            {
                return RedirectToAction("AllDeleted", "Team", new { area = "Admin" });
            }

            var playerModel = await playerService.GetPlayerReturnServiceModelByIdAsync(id);

            return View(playerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Return(PlayerDeleteServiceModel model)
        {
            if (await playerService.ExistsDeletedAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await playerService.ReturnAsync(model.Id);

            return RedirectToAction("AllDeleted");
        }

    }
}
