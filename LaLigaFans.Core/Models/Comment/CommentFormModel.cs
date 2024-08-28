using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Core.Models.Comment
{
    public class CommentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CommentTitleMaxLength,
            MinimumLength = CommentTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CommentContentMaxLength,
            MinimumLength = CommentContentMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        public int? CommentObjectId { get; set; }

    }
}
