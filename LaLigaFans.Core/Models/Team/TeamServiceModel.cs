using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.Team
{
    public class TeamServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Logo")]
        public string LogoUrl { get; set; } = null!;

        [Display(Name = "Coach name")]
        public string CoachName { get; set; } = null!;

        [Display(Name = "Founded year")]
        public int FoundedYear { get; set; }
    }
}
