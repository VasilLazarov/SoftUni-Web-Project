using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents mapping table between Cart entity and Product Entity in application
    /// </summary>
    [Comment("CartProduct is a mapping table entity class")]
    public class CartProduct
    {
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("Cart identifier")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;
    }
}
