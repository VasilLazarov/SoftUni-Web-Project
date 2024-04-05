using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a question in application
    /// </summary>
    [Comment("Question is a entity class")]
    public class Question
    {
        [Key]
        [Comment("Question identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(QuestionTitleMaxLength)]
        [Comment("Question title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(QuestionContentMaxLength)]
        [Comment("Question content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Question created on date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Question author identifier")]
        public string AuthorId { get; set; } = null!;

        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser Author { get; set; } = null!;

    }
}
