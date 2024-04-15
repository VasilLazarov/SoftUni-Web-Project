namespace LaLigaFans.Core.Models.Products
{
    public class ProductsQueryServiceModel
    {

        public int TotalProductCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();
    }
}
