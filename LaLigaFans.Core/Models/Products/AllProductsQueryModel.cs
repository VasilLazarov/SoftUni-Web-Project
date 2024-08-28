using LaLigaFans.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.Products
{
    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 8;

        public string Category { get; set; } = null!;

        public string Team { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public ProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> Teams { get; set; } = null!;

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();
    }
}
