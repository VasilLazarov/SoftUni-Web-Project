using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Enums;

namespace LaLigaFans.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int Id { get; set; }

        public string UserFullName { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; }

        public decimal TotalPrice { get; set; }

        public int ProductsCount { get; set; }

        public string City { get; set; } = null!;

        public string StreetEtc { get; set; } = null!;

        public IEnumerable<ProductServiceModel> Products
            = new List<ProductServiceModel>();
    }
}
