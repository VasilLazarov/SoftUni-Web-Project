using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.News
{
    public class NewsDeleteServiceModel : NewsServiceModel
    {
        public string Content { get; set; } = null!;

        [Display(Name = "Team Name")]
        public string TeamName { get; set; } = null!;
    }
}
