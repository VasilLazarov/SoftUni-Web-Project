﻿using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Contracts.OtherContracts;
using LaLigaFans.Core.Enums;
using LaLigaFans.Core.Models.News;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LaLigaFans.Core.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly IRepository repository;

        private readonly IUploadService uploadService;

        private readonly ICommentService commentService;

        public NewsService(
            IRepository _repository,
            IUploadService _uploadService,
            ICommentService _commentService)
        {
            repository = _repository;
            uploadService = _uploadService;
            commentService = _commentService;
        }

        public async Task<NewsQueryServiceModel> AllAsync(
            string userId,
            string? team = null,
            string? searchTerm = null,
            NewsSorting sorting = NewsSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1)
        {
            var newsQuery = repository.AllReadOnly<News>()
                .GetOnlyActiveNews();

            if (!string.IsNullOrEmpty(team))
            {
                newsQuery = newsQuery
                    .Where(n => n.Team.Name == team);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                newsQuery = newsQuery
                    .Where(n =>
                        n.Title.ToLower().Contains(searchTerm.ToLower()) ||
                        n.Content.ToLower().Contains(searchTerm.ToLower()));
            }

            newsQuery = sorting switch
            {
                NewsSorting.Oldest => newsQuery
                    .OrderBy(n => n.Id),
                NewsSorting.FollowedTeams => newsQuery
                    .OrderBy(n => n.Team.Followers.Any(ut => ut.ApplicationUserId == userId) == false),
                _ => newsQuery
                    .OrderByDescending(n => n.Id)
            };

            var news = await newsQuery
                .Skip((currentPage - 1) * newsPerPage)
                .Take(newsPerPage)
                .Select(n => new NewsServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageURL,
                    Owner = n.Owner.FirstName + " " +n.Owner.LastName,
                    PublishedOn = n.PublishedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                })
                .ToListAsync();

            var totalNews = await newsQuery.CountAsync();

            var newsAndCount = new NewsQueryServiceModel()
            {
                TotalNewsCount = totalNews,
                News = news
            };

            return newsAndCount;
        }


        public async Task<bool> HasPublisherWithIdAsync(int newsId, string userId)
        {
            return await repository.AllReadOnly<News>()
                .GetOnlyActiveNews()
                .AnyAsync(n => n.Id == newsId &&
                               n.Owner.Id == userId);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool result = await repository.AllReadOnly<News>()
                .GetOnlyActiveNews()
                .AnyAsync(n => n.Id == id);

            return result;
        }

        public async Task<NewsDetailsServiceModel> NewsDetailsByIdAsync(int id)
        {
            var teamWithDetails = await repository.AllReadOnly<News>()
                .Where(n => n.Id == id)
                .Select(n => new NewsDetailsServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageURL,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = n.Owner.FirstName + " " + n.Owner.LastName
                })
                .FirstAsync();

            teamWithDetails.Comments = await commentService.LastTwoNewsCommentsAsync(id);

            return teamWithDetails;
        }

        public async Task<int> CreateAsync(NewsAddFormModel model, string userId)
        {
            string imageUrl = model.Image.FileName;
            string folderName = "news";
            if (!await uploadService.UploadImage(model.Image, folderName))
            {
                imageUrl = "Default.png";
            }

            var news = new News()
            {
                Title = model.Title,
                Content = model.Content,
                TeamId = model.TeamId,
                ImageURL = imageUrl,
                OwnerId = userId,
                PublishedOn = DateTime.Now
            };

            await repository.AddAsync(news);
            await repository.SaveChangesAsync();

            return news.Id;
        }

        public async Task<NewsEditFormModel?> GetNewsEditFormModelByIdAsync(int newsId)
        {
            var newsModel = await repository.AllReadOnly<News>()
                .Where(n => n.Id == newsId)
                .Select(n => new NewsEditFormModel()
                {
                    Title = n.Title,
                    Content = n.Content,
                    TeamId = n.TeamId
                })
                .FirstOrDefaultAsync();

            return newsModel;
        }

        public async Task EditAsync(int newsId, NewsEditFormModel model)
        {
            var news = await repository.GetByIdAsync<News>(newsId);

            if(news != null)
            {
                news.Title = model.Title;
                news.Content = model.Content;
                news.TeamId = model.TeamId;

                if(model.Image != null)
                {
                    string imageUrl = model.Image.FileName;
                    string folderName = "news";
                    if (!await uploadService.UploadImage(model.Image, folderName))
                    {
                        imageUrl = "Default.png";
                    }
                    news.ImageURL = imageUrl;
                }
                await repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int newsId)
        {
            var news = await repository.GetByIdAsync<News>(newsId);

            if(news != null)
            {
                news.IsActive = false;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<NewsDeleteServiceModel?> GetNewsDeleteServiceModelByIdAsync(int newsId)
        {
            var newsModel = await repository.AllReadOnly<News>()
                .GetOnlyActiveNews()
                .Where(n => n.Id == newsId)
                .Select(n => new NewsDeleteServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    ImageUrl = n.ImageURL,
                    TeamName = n.Team.Name,
                    PublishedOn = n.PublishedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = n.Owner.FirstName + " " + n.Owner.LastName
                })
                .FirstOrDefaultAsync();

            return newsModel;
        }

        public async Task<NewsDeleteServiceModel?> GetNewsReturnServiceModelByIdAsync(int newsId)
        {
            var newsModel = await repository.AllReadOnly<News>()
                .GetDeletedNews()
                .Where(n => n.Id == newsId)
                .Select(n => new NewsDeleteServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    ImageUrl = n.ImageURL,
                    TeamName = n.Team.Name,
                    PublishedOn = n.PublishedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = n.Owner.FirstName + " " + n.Owner.LastName
                })
                .FirstOrDefaultAsync();

            return newsModel;
        }

        public async Task ReturnAsync(int newsId)
        {
            var news = await repository.All<News>()
                .GetDeletedNews()
                .Where(n => n.Id == newsId)
                .FirstOrDefaultAsync();

            if(news != null)
            {
                news.IsActive = true;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<NewsQueryServiceModel> AllDeletedAsync(int currentPage = 1, int newsPerPage = 1)
        {
            var news = await repository.AllReadOnly<News>()
                .GetDeletedNews()
                .Skip((currentPage - 1) * newsPerPage)
                .Take(newsPerPage)
                .Select(n => new NewsServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageURL,
                    Owner = n.Owner.FirstName + " " + n.Owner.LastName,
                    PublishedOn = n.PublishedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                })
                .ToListAsync();

            var totalNews = await repository.AllReadOnly<News>()
                .GetDeletedNews()
                .CountAsync();

            var newsAndCount = new NewsQueryServiceModel()
            {
                TotalNewsCount = totalNews,
                News = news
            };

            return newsAndCount;
        }

        public async Task<bool> ExistsDeletedAsync(int newsId)
        {
            bool result = await repository.AllReadOnly<News>()
                .GetDeletedNews()
                .AnyAsync(n => n.Id == newsId);

            return result;
        }

        public async Task<bool> ExistsNewsTeamAsync(int newsId)
        {
            var news = await repository.AllReadOnly<News>()
                .FirstOrDefaultAsync(n => n.Id == newsId);

            if (news == null)
            {
                return false;
            }

            bool result = await repository.AllReadOnly<Team>()
                .GetOnlyActiveTeams()
                .AnyAsync(t => t.Id == news.TeamId);

            return result;
        }
    }
}
