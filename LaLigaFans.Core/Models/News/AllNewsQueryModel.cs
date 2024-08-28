using LaLigaFans.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.News
{
    public class AllNewsQueryModel
    {
        public const int NewsPerPage = 4;

        public string Team { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public NewsSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalNewsCount { get; set; }

        public IEnumerable<string> Teams { get; set; } = null!;

        public IEnumerable<NewsServiceModel> News { get; set; }
            = new List<NewsServiceModel>();
    }
}
