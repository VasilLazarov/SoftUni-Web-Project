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

        public DbSet<Address> Addresses { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<News> News { get; set; } = null!;

        public DbSet<Order> Order { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        public DbSet<Player> Players { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Question> Questions { get; set; } = null!;

        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<ApplicationUserProduct> ApplicationUsersProducts { get; set; } = null!;

        public DbSet<ApplicationUserTeam> ApplicationUsersTeams { get; set; } = null!;

        public DbSet<CartProduct> CartsProducts { get; set; } = null!;


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
