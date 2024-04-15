using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Core.Models.News
{
    public class NewsEditFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsTitleMaxLength,
            MinimumLength = NewsTitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Display(Name = "News Image")]
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsContentMaxLength,
            MinimumLength = NewsContentMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamBasicServiceModel> Teams { get; set; }
            = new List<TeamBasicServiceModel>();
    }
}
