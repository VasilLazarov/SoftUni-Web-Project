using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static LaLigaFans.Infrastructure.Constants.AdminConstants;
using static LaLigaFans.Infrastructure.Constants.CustomClaims;

namespace LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds
{
    internal class SeedApplicationUsers
    {
        public ApplicationUser AdminUser { get; set; } = null!;

        public IdentityUserClaim<string> AdminUserClaim { get; set; } = null!;

        public IdentityRole AdminRole { get; set; } = null!;

        public IdentityUserRole<string> AdminUserAdminRole { get; set; } = null!;

        public ApplicationUser PublisherUser { get; set; } = null!;

        public IdentityUserClaim<string> PublisherUserClaim { get; set; } = null!;

        public IdentityRole PublisherRole { get; set; } = null!;

        public IdentityUserRole<string> PublisherUserPublisherRole { get; set; } = null!;

        public ApplicationUser OrdinaryUser { get; set; } = null!;

        public IdentityUserClaim<string> OrdinaryUserClaim { get; set; } = null!;

        public IdentityRole UserRole { get; set; } = null!;

        public IdentityUserRole<string> OrdinaryUserUserRole { get; set; } = null!;



        public SeedApplicationUsers()
        {
            SeedUsers();
            SeedClaims();
            SeedRoles();
            SeedUsersRoles();
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "1dcd54f5-dc66-4540-8cf9-d44658029bfd",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                FirstName = "Admin",
                LastName = "Adminov"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin-7777?");

            PublisherUser = new ApplicationUser()
            {
                Id = "176d92cc-bdaf-4569-94b8-fa377f980d89",
                UserName = "publisher@gmail.com",
                NormalizedUserName = "PUBLISHER@GMAIL.COM",
                Email = "publisher@gmail.com",
                NormalizedEmail = "PUBLISHER@GMAIL.COM",
                FirstName = "Publisher",
                LastName = "Ivanov"
            };

            PublisherUser.PasswordHash = hasher.HashPassword(PublisherUser, "Publisher-77?");

            OrdinaryUser = new ApplicationUser()
            {
                Id = "9ec8c321-e4d2-4ec4-854c-81b04f6b53c6",
                UserName = "user1@gmail.com",
                NormalizedUserName = "USER1@GMAIL.COM",
                Email = "user1@gmail.com",
                NormalizedEmail = "USER1@GMAIL.COM",
                FirstName = "User",
                LastName = "Userov"
            };

            OrdinaryUser.PasswordHash = hasher.HashPassword(OrdinaryUser, "User-77777?");
        }

        private void SeedClaims()
        {
            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                UserId = AdminUser.Id,
                ClaimType = UserFullNameClaim,
                ClaimValue = $"{AdminUser.FirstName} {AdminUser.LastName}"
            };

            PublisherUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                UserId = PublisherUser.Id,
                ClaimType = UserFullNameClaim,
                ClaimValue = $"{PublisherUser.FirstName} {PublisherUser.LastName}"
            };

            OrdinaryUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                UserId = OrdinaryUser.Id,
                ClaimType = UserFullNameClaim,
                ClaimValue = $"{OrdinaryUser.FirstName} {OrdinaryUser.LastName}"
            };
        }

        private void SeedRoles()
        {
            AdminRole = new IdentityRole()
            {
                Id = "18c72cdd-60c4-4a26-b931-d183cb23e593",
                Name = AdminRoleName,
                NormalizedName = AdminRoleName.ToUpper()
            };

            PublisherRole = new IdentityRole()
            {
                Id = "91accf42-f5d3-47ee-8300-4671d5b47e46",
                Name = "Publisher",
                NormalizedName = "PUBLISHER"
            };

            UserRole = new IdentityRole()
            {
                Id = "f9725b78-b6af-40c1-90d4-f77de178c1fd",
                Name = "User",
                NormalizedName = "USER"
            };
        }

        private void SeedUsersRoles()
        {
            AdminUserAdminRole = new IdentityUserRole<string>()
            {
                UserId = AdminUser.Id,
                RoleId = AdminRole.Id
            };

            PublisherUserPublisherRole = new IdentityUserRole<string>()
            {
                UserId = PublisherUser.Id,
                RoleId = PublisherRole.Id
            };

            OrdinaryUserUserRole = new IdentityUserRole<string>()
            {
                UserId = OrdinaryUser.Id,
                RoleId = UserRole.Id
            };
        }

    }
}
