using LaLigaFans.Core.Models.Comment;

namespace LaLigaFans.Core.Contracts.CommentContracts
{
    public interface ICommentService
    {
        Task CreateNewsCommentAsync(int newsId, string userId, string title, string content);

        Task CreateProductCommentAsync(int productId, string userId, CommentFormModel model);

        Task<IEnumerable<CommentServiceModel>> LastTwoNewsCommentsAsync(
            int newsId);

        Task<IEnumerable<CommentServiceModel>> LastTwoProductCommentsAsync(
            int productId);


    }
}
