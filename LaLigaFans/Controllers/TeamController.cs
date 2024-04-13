using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaFans.Controllers
{
    public class TeamController : BaseController
    {
        public readonly ITeamService teamService;

        public TeamController(ITeamService _teamService)
        {
            teamService = _teamService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllTeamsQueryModel query)
        {
            var queryResult = await teamService.AllAsync(
                query.CurrentPage,
                AllTeamsQueryModel.TeamsPerPage);

            query.TotalTeamsCount = queryResult.TotalTeamsCount;
            query.Teams = queryResult.Teams;

            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var teamModel = await teamService.TeamDetailsByIdAsync(id);

            return View(teamModel);
        }
    }
}
