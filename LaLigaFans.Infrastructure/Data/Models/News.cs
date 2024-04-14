using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents news in application
    /// </summary>
    [Comment("News is a entity class")]
    public class News
    {
        [Key]
        [Comment("News identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsTitleMaxLength)]
        [Comment("News title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(NewsImageUrlMaxLength)]
        [Comment("News image URL")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [MaxLength(NewsContentMaxLength)]
        [Comment("News content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("News published date")]
        public DateTime PublishedOn { get; set; }

        [Comment("Identifier of team the news is about")]
        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team? Team { get; set; }

        [Required]
        [Comment("News owner identifier")]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; }
            = new HashSet<Comment>();
    }
}
