using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a product in application
    /// </summary>
    [Comment("Product is a entity class")]
    public class Product
    {
        [Key]
        [Comment("Product identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Product name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Product description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProductImageUrlMaxLength)]
        [Comment("Product image URL")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Product available units")]
        public int UnitsAvailable { get; set; }

        [Required]
        [Comment("Product likes")]
        public int Likes { get; set; }

        [Required]
        [Comment("Product dislikes")]
        public int DisLikes { get; set; }

        [Required]
        [Comment("Product category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Product team identifier")]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        public ICollection<CartProduct> CartsProducts { get; set; }
            = new HashSet<CartProduct>();

        public ICollection<ApplicationUserProduct> UsersFavorite { get; set; }
            = new HashSet<ApplicationUserProduct>();

        public ICollection<Comment> Comments { get; set; }
            = new HashSet<Comment>();
    }
}
