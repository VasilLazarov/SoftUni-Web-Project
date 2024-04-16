using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a order in application
    /// </summary>
    [Comment("Order is a entity class")]
    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Order buyer identifier")]
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        [Comment("Order payment identifier")]
        public int PaymentId { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; } = null!;

        [Required]
        [Comment("Order address identifier")]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;

        public ICollection<OrderProduct> OrdersProducts { get; set; }
            = new HashSet<OrderProduct>();
    }
}
