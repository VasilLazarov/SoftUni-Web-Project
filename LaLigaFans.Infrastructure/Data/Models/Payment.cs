using LaLigaFans.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a payment in application
    /// </summary>
    [Comment("Payment is a entity class")]
    public class Payment
    {
        [Key]
        [Comment("Payment identifier")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Payment total price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Payment method")]
        public PaymentMethod PaymentMethod { get; set; }

        public Order Order { get; set; } = null!;

    }
}
