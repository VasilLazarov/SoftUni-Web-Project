using LaLigaFans.Core.Models.Team;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Core.Models.Products
{
    public class ProductAddFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = UploadImageErrorMessage)]
        [Display(Name = "Product Image")]
        public IFormFile Image { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProductDescriptionMaxLength,
            MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            ProductPriceMin,
            ProductPriceMax,
            ErrorMessage = RangeMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ProductUnitsAvailableMin,
            ProductUnitsAvailableMax,
            ErrorMessage = RangeMessage)]
        [Display(Name = "Units Available")]
        public int UnitsAvailable { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<TeamBasicServiceModel> Teams { get; set; }
            = new List<TeamBasicServiceModel>();

        public IEnumerable<ProductCategory> Categories { get; set; }
            = new List<ProductCategory>();
    }
}
