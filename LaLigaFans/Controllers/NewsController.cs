﻿using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.TeamContracts;
using LaLigaFans.Core.Models.Comment;
using LaLigaFans.Core.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Core.Constants.RoleNamesConstants;


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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (User.IsAdmin())
            {
                if (await newsService.ExistsAsync(id) == false && await newsService.ExistsDeletedAsync(id) == false)
                {
                    return BadRequest();
                }
            }
            else
            {
                if (await newsService.ExistsAsync(id) == false)
                {
                    return BadRequest();
                }
            }

            var newsModel = await newsService.NewsDetailsByIdAsync(id);
            newsModel.CommentForm = new CommentFormModel()
            {
                CommentObjectId = id
            };

            return View(newsModel);
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRoleName}, {PublisherRoleName}")]
        public async Task<IActionResult> Add()
        {
            var model = new NewsAddFormModel()
            {
                Teams = await teamService.GetTeamIdsAndNames()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = $"{AdminRoleName}, {PublisherRoleName}")]
        public async Task<IActionResult> Add(NewsAddFormModel model)
        {
            if (await teamService.ExistsAsync(model.TeamId) == false)
            {
                ModelState.AddModelError(nameof(model.TeamId), TeamErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Teams = await teamService.GetTeamIdsAndNames();
                return View(model);
            }

            var userId = User.Id();
            int newNewsId = await newsService.CreateAsync(model, userId);

            return RedirectToAction(nameof(Details), new { area = "", id = newNewsId });
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRoleName}, {PublisherRoleName}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (await newsService.ExistsAsync(id) == false && await newsService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            if (!User.IsAdmin() && (await newsService.HasPublisherWithIdAsync(id, userId) == false))
            {
                return Unauthorized();
            }

            var newsModel = await newsService.GetNewsEditFormModelByIdAsync(id);

            if (newsModel != null)
            {
                newsModel.Teams = await teamService.GetTeamIdsAndNames();
            }

            return View(newsModel);
        }


        [HttpPost]
        [Authorize(Roles = $"{AdminRoleName}, {PublisherRoleName}")]
        public async Task<IActionResult> Edit(int id, NewsEditFormModel model)
        {
            if (await newsService.ExistsAsync(id) == false && await newsService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            if (!User.IsAdmin() && (await newsService.HasPublisherWithIdAsync(id, userId) == false))
            {
                return Unauthorized();
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

            await newsService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { area = "", id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await newsService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            if (!User.IsAdmin() && (await newsService.HasPublisherWithIdAsync(id, userId) == false))
            {
                return Unauthorized();
            }

            var newsModel = await newsService.GetNewsDeleteServiceModelByIdAsync(id);

            return View(newsModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewsDeleteServiceModel model)
        {
            if (await newsService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            if (!User.IsAdmin() && (await newsService.HasPublisherWithIdAsync(model.Id, userId) == false))
            {
                return Unauthorized();
            }

            await newsService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRoleName}")]
        public async Task<IActionResult> AllDeleted([FromQuery] AllNewsQueryModel query)
        {
            var queryResult = await newsService.AllDeletedAsync(
                query.CurrentPage,
                AllNewsQueryModel.NewsPerPage);

            query.TotalNewsCount = queryResult.TotalNewsCount;
            query.News = queryResult.News;

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRoleName}")]
        public async Task<IActionResult> Return(int id)
        {
            if (await newsService.ExistsDeletedAsync(id) == false)
            {
                return BadRequest();
            }

            if (await newsService.ExistsNewsTeamAsync(id) == false)
            {
                return RedirectToAction("AllDeleted", "Team", new { area = "Admin" });
            }

            var newsModel = await newsService.GetNewsReturnServiceModelByIdAsync(id);

            return View(newsModel);
        }

        [HttpPost]
        [Authorize(Roles = $"{AdminRoleName}")]
        public async Task<IActionResult> Return(NewsDeleteServiceModel model)
        {
            if (await newsService.ExistsDeletedAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await newsService.ReturnAsync(model.Id);

            return RedirectToAction("AllDeleted");
        }

    }
}
