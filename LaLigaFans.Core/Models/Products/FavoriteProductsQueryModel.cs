using LaLigaFans.Core.Models.Team;

namespace LaLigaFans.Core.Models.Products
{
    public class FavoriteProductsQueryModel
    {
        public const int ProductsPerPage = 8;

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();
    }
}
