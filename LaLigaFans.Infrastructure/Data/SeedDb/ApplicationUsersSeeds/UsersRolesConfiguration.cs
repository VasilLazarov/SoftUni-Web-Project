using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds
{
    internal class UsersRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var seedData = new SeedApplicationUsers();

            builder.HasData(seedData.AdminUserAdminRole, seedData.PublisherUserPublisherRole, seedData.OrdinaryUserUserRole);
        }
    }
}
