using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var seedData = new SeedApplicationUsers();

            builder.HasData(seedData.AdminUser, seedData.PublisherUser, seedData.OrdinaryUser);
        }
    }
}
