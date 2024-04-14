using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Areas.Admin.Controllers
{
    public class TeamController : AdminBaseController
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService _teamService)
        {
            teamService = _teamService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new TeamAddFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TeamAddFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int newTeamId = await teamService.CreateAsync(model);

            return RedirectToAction("Details", "Team", new { area = "", id = newTeamId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var teamModel = await teamService.GetTeamEditFormModelByIdAsync(id);

            return View(teamModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeamEditFormModel model)
        {
            if (await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await teamService.EditAsync(id, model);

            return RedirectToAction("Details", "Team", new { area = "", id = id});
        }



    }
}
