using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LaLigaFans.Infrastructure.Constants.DataConstants;


namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a football team in application
    /// </summary>
    [Comment("Team is a entity class")]
    public class Team
    {
        [Key]
        [Comment("Team identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TeamNameMaxLength)]
        [Comment("Team name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(TeamLogoUrlMaxLength)]
        [Comment("Team logo URL")]
        public string LogoUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Team founded year")]
        public int FoundedYear { get; set; }

        [Required]
        [MaxLength(TeamCoachNameMaxLength)]
        [Comment("Team coach name")]
        public string CoachName { get; set; } = string.Empty;

        [Required]
        [MaxLength(TeamInformationMaxLength)]
        [Comment("Team information")]
        public string Information { get; set; } = string.Empty;

        public ICollection<Player> Players { get; set; }
            = new HashSet<Player>();

        public ICollection<ApplicationUserTeam> Followers { get; set; }
            = new HashSet<ApplicationUserTeam>();

        public ICollection<News> News { get; set; }
            = new HashSet<News>();

        public ICollection<Product> Products { get; set; }
            = new HashSet<Product>();
    }
}
