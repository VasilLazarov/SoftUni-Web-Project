using System.ComponentModel.DataAnnotations;

namespace LaLigaFans.Core.Models.Products
{
    public class ProductDeleteServiceModel : ProductServiceModel
    {
        public string Description { get; set; } = null!;

        [Display(Name = "Units Available")]
        public int UnitsAvailable { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; } = null!;

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = null!;


    }
}
