using LaLigaFans.Core.Contracts.NewsContracts;
using LaLigaFans.Core.Enums;
using LaLigaFans.Core.Models.News;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace LaLigaFans.Core.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly IRepository repository;

        public NewsService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<NewsQueryServiceModel> AllAsync(
            string userId,
            string? team = null,
            string? searchTerm = null,
            NewsSorting sorting = NewsSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1)
        {
            var newsQuery = repository.AllReadOnly<News>();

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
                    Content = n.Content,
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
                .AnyAsync(n => n.Id == newsId &&
                               n.Owner.Id == userId);
        }



    }
}
