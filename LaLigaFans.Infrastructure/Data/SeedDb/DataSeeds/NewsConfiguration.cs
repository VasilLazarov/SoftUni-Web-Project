using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .Property(n => n.IsActive)
                .HasDefaultValue(true);

            var data = new SeedData();

            builder
                .HasData(data.News1,
                         data.News2,
                         data.News3,
                         data.News4,
                         data.News5,
                         data.News6);
        }
    }
}
