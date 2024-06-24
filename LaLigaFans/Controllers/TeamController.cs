using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

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
            if (User.IsAdmin())
            {
                if (await teamService.ExistsAsync(id) == false && await teamService.ExistsDeletedAsync(id) == false)
                {
                    return BadRequest();
                }
            }
            else{
                if (await teamService.ExistsAsync(id) == false)
                {
                    return BadRequest();
                }
            }

            var teamModel = await teamService.TeamDetailsByIdAsync(id);

            return View(teamModel);
        }

        [HttpPost]
        public async Task<IActionResult> Follow(int id)
        {
            if (await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (await teamService.IsFollowedByUserWithIdAsync(id, userId))
            {
                return BadRequest();
            }

            await teamService.FollowAsync(id, userId);

            return RedirectToAction(nameof(Followed));
        }

        [HttpPost]
        public async Task<IActionResult> Unfollow(int id)
        {
            if (await teamService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (await teamService.IsFollowedByUserWithIdAsync(id, userId) == false)
            {
                return BadRequest();
            }

            await teamService.UnfollowAsync(id, userId);

            return RedirectToAction(nameof(Followed));
        }

        [HttpGet]
        public async Task<IActionResult> Followed([FromQuery] AllTeamsQueryModel query)
        {
            var queryResult = await teamService.FollowedAsync(
                User.Id(),
                query.CurrentPage,
                AllTeamsQueryModel.TeamsPerPage);

            query.TotalTeamsCount = queryResult.TotalTeamsCount;
            query.Teams = queryResult.Teams;

            return View(query);
        }
    }
}
