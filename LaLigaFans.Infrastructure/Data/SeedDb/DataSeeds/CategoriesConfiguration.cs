using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder
                .HasData(data.TShirt,
                         data.Scarf,
                         data.Ball,
                         data.Cup,
                         data.Bag,
                         data.Keychain);
        }
    }
}
