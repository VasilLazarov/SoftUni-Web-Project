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

        public NewsService(
            IRepository _repository,
            IUploadService _uploadService)
        {
            repository = _repository;
            uploadService = _uploadService;
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

        public async Task<bool> ExistsAsync(int id)
        {
            bool result = await repository.AllReadOnly<News>()
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




    }
}
