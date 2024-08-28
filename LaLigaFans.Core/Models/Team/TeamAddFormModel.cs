using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Core.Models.Team
{
    public class TeamAddFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TeamNameMaxLength,
            MinimumLength = TeamNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = UploadImageErrorMessage)]
        [Display(Name = "Team Logo")]
        public IFormFile ImageLogo { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(TeamFoundedYearMin, TeamFoundedYearMax,
            ErrorMessage = NumberErrorMessage)]
        [Display(Name = "Founded Year")]
        public int FoundedYear { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TeamLogoUrlMaxLength,
            MinimumLength = TeamLogoUrlMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Coach Name")]
        public string CoachName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TeamInformationMaxLength,
            MinimumLength = TeamInformationMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Information { get; set; } = null!;


    }
}
