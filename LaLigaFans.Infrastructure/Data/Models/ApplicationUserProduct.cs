using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents mapping table between ApplicationUser entity and Product Entity in application
    /// </summary>
    [Comment("ApplicationUserProduct is a mapping table entity class")]
    public class ApplicationUserProduct
    {
        [Comment("ApplicationUser identifier")]
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
