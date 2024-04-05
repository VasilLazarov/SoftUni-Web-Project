using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a address in application
    /// </summary>
    [Comment("Address is a entity class")]
    public class Address
    {
        [Key]
        [Comment("Address identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AddressCityMaxName)]
        [Comment("Address city")]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressStreetMaxName)]
        [Comment("Address street etc")]
        public string StreetEtc { get; set; } = string.Empty;

        [Required]
        [Comment("Payment order identifier")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}
