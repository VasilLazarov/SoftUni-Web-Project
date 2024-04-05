using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a cart in application
    /// </summary>
    [Comment("Cart is a entity class")]
    public class Cart
    {
        [Key]
        [Comment("Cart identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Cart applicaion user identifier")]
        public string ApplicationUserId { get; set; } = string.Empty;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public ICollection<CartProduct> CartsProducts { get; set; }
            = new HashSet<CartProduct>();
    }
}
