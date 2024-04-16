using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents mapping table between Order entity and Product Entity in application
    /// </summary>
    [Comment("OrderProduct is a mapping table entity class")]
    public class OrderProduct
    {
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("Order identifier")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}
