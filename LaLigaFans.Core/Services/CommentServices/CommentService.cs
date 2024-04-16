using LaLigaFans.Core.Contracts.CommentContracts;
using LaLigaFans.Core.Models.Comment;
using LaLigaFans.Infrastructure.Data.Comman;
using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LaLigaFans.Core.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateNewsCommentAsync(int newsId, string userId, string title, string content)
        {
            var newsComment = new Comment()
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.Now,
                AuthorId = userId,
                NewsId = newsId
            };

            await repository.AddAsync(newsComment);
            await repository.SaveChangesAsync();
        }

        public async Task CreateProductCommentAsync(int productId, string userId, CommentFormModel model)
        {
            var productComment = new Comment()
            {
                Title = model.Title,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                AuthorId = userId,
                ProductId = productId
            };

            await repository.AddAsync(productComment);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentServiceModel>> LastTwoNewsCommentsAsync(
            int newsId)
        {
            var comments = await repository.AllReadOnly<Comment>()
                .GetOnlyActiveComments()
                .Where(c => c.NewsId == newsId)
                .OrderByDescending(c => c.Id)
                .Take(2)
                .Select(c => new CommentServiceModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Content = c.Content,
                    Author = c.Author.FirstName + " " + c.Author.LastName,
                    CreatedOn = c.CreatedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return comments;
        }


        public async Task<IEnumerable<CommentServiceModel>> LastTwoProductCommentsAsync(
            int productId)
        {
            var comments = await repository.AllReadOnly<Comment>()
                .GetOnlyActiveComments()
                .Where(c => c.ProductId == productId)
                .OrderByDescending(c => c.Id)
                .Take(2)
                .Select(c => new CommentServiceModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Content = c.Content,
                    Author = c.Author.FirstName + " " + c.Author.LastName,
                    CreatedOn = c.CreatedOn.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return comments;
        }

        public async Task<CommentDeleteServiceModel> DeleteAsync(int commentId)
        {
            var comment = await repository.GetByIdAsync<Comment>(commentId);

            var resultModel = new CommentDeleteServiceModel();

            if (comment != null)
            {
                resultModel.ObjectId = comment.NewsId;
                resultModel.ObjectType = "News";

                if(comment.NewsId == null)
                {
                    resultModel.ObjectId = comment.ProductId;
                    resultModel.ObjectType = "Product";
                }
                comment.IsActive = false;

                await repository.SaveChangesAsync();
            }

            return resultModel;
        }

        public async Task<bool> ExistsAsync(int commentId)
        {
            var result = await repository.AllReadOnly<Comment>()
                .GetOnlyActiveComments()
                .AnyAsync(c => c.Id == commentId);

            return result;
        }


    }
}
