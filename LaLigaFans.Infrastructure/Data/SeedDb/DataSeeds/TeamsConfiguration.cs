using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .Property(t => t.IsActive)
                .HasDefaultValue(true);

            var data = new SeedData();

            builder
                .HasData(data.Barcelona, 
                         data.RealMadrid, 
                         data.AtleticoMadrid,
                         data.Valencia,
                         data.Sevilla,
                         data.Girona,
                         data.Alaves);
        }
    }
}
