using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds
{
    internal class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var seedData = new SeedApplicationUsers();

            builder.HasData(seedData.AdminUserClaim, seedData.PublisherUserClaim, seedData.OrdinaryUserClaim);
        }
    }
}
