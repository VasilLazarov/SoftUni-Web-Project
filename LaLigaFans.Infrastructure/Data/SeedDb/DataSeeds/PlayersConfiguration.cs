using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class PlayersConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
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
