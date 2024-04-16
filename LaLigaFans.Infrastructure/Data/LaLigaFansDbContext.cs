using LaLigaFans.Infrastructure.Data.Models;
using LaLigaFans.Infrastructure.Data.SeedDb.ApplicationUsersSeeds;
using LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds;
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
        
        public DbSet<OrderProduct> OrdersProducts { get; set; } = null!;


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

            builder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(pk => new { pk.ProductId, pk.OrderId });
            });

            builder
                .Entity<Comment>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new IdentityRolesConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());

            builder.ApplyConfiguration(new CartsConfiguration());
            builder.ApplyConfiguration(new TeamsConfiguration());
            builder.ApplyConfiguration(new PlayersConfiguration());
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new CategoriesConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());


            //Apply entity models configurations
            //..................................

            base.OnModelCreating(builder);
        }

    }
}
