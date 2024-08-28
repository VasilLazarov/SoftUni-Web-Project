using LaLigaFans.Core.Models.Products;
using System.Xml.Schema;

namespace LaLigaFans.Core.Models.Cart
{
    public class CartServiceModel
    {
        public int Id { get; set; } 

        public decimal TotalPrice { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();

    }
}
