using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds
{
    internal class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var seedData = new SeedApplicationUsers();

            builder.HasData(seedData.AdminRole, seedData.PublisherRole, seedData.UserRole);
        }
    }
}
