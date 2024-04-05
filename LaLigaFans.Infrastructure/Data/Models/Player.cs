using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a football player from some team in application
    /// </summary>
    [Comment("Player is a entity class")]
    public class Player
    {
        [Key]
        [Comment("Player identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PlayerFirstNameMaxLength)]
        [Comment("Player first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PlayerLastNameMaxLength)]
        [Comment("Player last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Comment("Player age")]
        public int Age { get; set; }

        [Required]
        [MaxLength(PlayerImageUrlMaxLength)]
        [Comment("Player image URL")]
        public string PlayerImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Player team id")]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

    }
}
