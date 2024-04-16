using LaLigaFans.Core.Models.Products;
using LaLigaFans.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Core.Constants.MessageConstants;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Core.Models.Order
{
    public class OrderFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public int CartId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public decimal TotalPrice { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
            = new List<ProductServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Payment method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressCityMaxName,
            MinimumLength = AddressCityMinName,
            ErrorMessage = StringLengthErrorMessage)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressStreetMaxName,
            MinimumLength = AddressStreetMinName,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Street etc.")]
        public string StreetEtc { get; set; } = null!;
    }
}
