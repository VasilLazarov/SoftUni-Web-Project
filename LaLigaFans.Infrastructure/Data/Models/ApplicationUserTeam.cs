using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents mapping table between ApplicationUser entity and Team Entity in application
    /// </summary>
    [Comment("ApplicationUserTeam is a mapping table entity class")]
    public class ApplicationUserTeam
    {
        [Comment("ApplicationUser identifier")]
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Team identifier")]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;
    }
}
