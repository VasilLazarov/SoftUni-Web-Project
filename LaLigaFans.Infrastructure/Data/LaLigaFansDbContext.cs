using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Infrastructure.Data
{
    public class LaLigaFansDbContext : IdentityDbContext<ApplicationUser>
    {
        public LaLigaFansDbContext(DbContextOptions<LaLigaFansDbContext> options)
            : base(options)
        {

        }

        //Implement DbSets
        //................

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartProduct>(entity =>
            {
                entity.HasKey(pk => new { pk.ProductId, pk.CartId });
            });

            builder.Entity<ApplicationUserProduct>(entity =>
            {
                entity.HasKey(pk => new { pk.ProductId, pk.ApplicationUserId });
            });

            builder.Entity<ApplicationUserTeam>(entity =>
            {
                entity.HasKey(pk => new { pk.TeamId, pk.ApplicationUserId });
            });

            
            //Apply entity models configurations
            //..................................

            base.OnModelCreating(builder);
        }

    }
}
