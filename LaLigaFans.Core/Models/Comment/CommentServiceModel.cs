namespace LaLigaFans.Core.Models.Comment
{
    public class CommentServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
