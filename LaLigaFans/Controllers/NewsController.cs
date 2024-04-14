using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaLigaFans.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;

        private readonly ITeamService teamService;

        public NewsController(
            INewsService _newsService,
            ITeamService _teamService)
        {
            newsService = _newsService;
            teamService = _teamService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllNewsQueryModel query)
        {
            var userId = User.Id();

            var queryResult = await newsService.AllAsync(
                userId,
                query.Team,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllNewsQueryModel.NewsPerPage);

            query.TotalNewsCount = queryResult.TotalNewsCount;
            query.News = queryResult.News;

            var teamNames = await teamService.AllTeamNamesAsync();
            query.Teams = teamNames;
            
            return View(query);
        }

        
    }
}
