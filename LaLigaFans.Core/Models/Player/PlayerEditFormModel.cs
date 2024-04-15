using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Core.Models.Player
{
    public class PlayerEditFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PlayerFirstNameMaxLength,
            MinimumLength = PlayerFirstNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PlayerLastNameMaxLength,
            MinimumLength = PlayerLastNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(PlayerAgeMin, PlayerAgeMax,
            ErrorMessage = NumberErrorMessage)]
        [Display(Name = "Player's Age")]
        public int Age { get; set; }

        [Display(Name = "Player Image")]
        public IFormFile? Image { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamBasicServiceModel> Teams { get; set; }
            = new List<TeamBasicServiceModel>();
    }
}
