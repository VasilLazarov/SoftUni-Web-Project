﻿using LaLigaFans.Core.Enums;
using LaLigaFans.Core.Models.News;

namespace LaLigaFans.Core.Contracts.NewsContracts
{
    public interface INewsService
    {

        Task<NewsQueryServiceModel> AllAsync(
            string userId,
            string? team = null,
            string? searchTerm = null,
            NewsSorting sorting = NewsSorting.Newest,
            int currentPage = 1,
            int newsPerPage = 1);

        Task<bool> HasPublisherWithIdAsync(int newsId, string userId);

    }
}