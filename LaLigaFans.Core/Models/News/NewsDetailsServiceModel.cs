using LaLigaFans.Core.Models.Comment;

namespace LaLigaFans.Core.Models.News
{
    public class NewsDetailsServiceModel : NewsServiceModel
    {
        public string Content { get; set; } = null!;

        public IEnumerable<CommentServiceModel> Comments { get; set; } = null!;

        public CommentFormModel CommentForm { get; set; } = null!;

    }
}
