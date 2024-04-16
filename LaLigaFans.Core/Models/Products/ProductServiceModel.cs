using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.Products
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int UnitsAvailable { get; set; }


    }
}
