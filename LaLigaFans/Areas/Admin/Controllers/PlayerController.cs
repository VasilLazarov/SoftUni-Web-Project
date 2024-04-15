using LaLigaFans.Core.Contracts.PlayerContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Player;
using Microsoft.AspNetCore.Mvc;
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
            var model = new PlayerAddFormModel()
            {
                Teams = await teamService.GetTeamIdsAndNames()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlayerAddFormModel model)
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
            if(await playerService.ExistsAsync(id) == false)
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
            if (await playerService.ExistsAsync(id) == false)
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



    }
}
