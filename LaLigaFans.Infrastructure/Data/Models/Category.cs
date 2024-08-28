using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a category of product in application
    /// </summary>
    [Comment("Category is a entity class")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; }
            = new HashSet<Product>();
    }
}
