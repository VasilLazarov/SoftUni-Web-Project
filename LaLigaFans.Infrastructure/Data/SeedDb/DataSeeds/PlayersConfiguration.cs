using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class PlayersConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            var data = new SeedData();

            builder
                .HasData(data.BarcaPlayer1,
                         data.BarcaPlayer2,
                         data.BarcaPlayer3,
                         data.BarcaPlayer4,
                         data.BarcaPlayer5,
                         data.RealPlayer1,
                         data.RealPlayer2,
                         data.RealPlayer3,
                         data.RealPlayer4,
                         data.AtleticoPlayer1,
                         data.AtleticoPlayer2,
                         data.ValenciaPlayer,
                         data.SevillaPlayer,
                         data.GironaPlayer,
                         data.AlavesPlayer);
        }
    }
}
