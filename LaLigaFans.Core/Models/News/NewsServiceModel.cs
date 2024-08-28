using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.News
{
    public class NewsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Published on")]
        public string PublishedOn { get; set; } = null!;

        public string Owner { get; set; } = null!;

    }
}
