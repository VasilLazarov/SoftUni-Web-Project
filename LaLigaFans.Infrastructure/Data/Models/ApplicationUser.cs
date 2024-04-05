using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LaLigaFans.Infrastructure.Constants.DataConstants;

namespace LaLigaFans.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents user in the application.
    /// ApplicationUser is a class that extends IdentityUser.
    /// </summary>
    [Comment("ApplicationUser is a entity class that extends IdentityUser")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("Application user first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [PersonalData]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("Application user last name")]
        public string LastName { get; set; } = string.Empty;

        public Cart Cart { get; set; } = null!;

        public ICollection<ApplicationUserProduct> FavoriteProducts { get; set; }
            = new HashSet<ApplicationUserProduct>();

        public ICollection<ApplicationUserTeam> FollowedTeams { get; set; }
            = new HashSet<ApplicationUserTeam>();

        public ICollection<Order> Orders { get; set; }
            = new HashSet<Order>();

    }
}
