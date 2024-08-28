using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a comment in application
    /// </summary>
    [Comment("Comment is a entity class")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentTitleMaxLength)]
        [Comment("Comment title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(CommentContentMaxLength)]
        [Comment("Comment content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Comment creation date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Comment author")]
        public string AuthorId { get; set; } = string.Empty;

        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser Author { get; set; } = null!;

        [Comment("Comment news identifier")]
        public int? NewsId { get; set; }

        [ForeignKey(nameof(NewsId))]
        public News? News { get; set; }

        [Comment("Comment product identifier")]
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Required]
        [Comment("Comment is active or not active(soft deleted)")]
        public bool IsActive { get; set; }
    }
}
