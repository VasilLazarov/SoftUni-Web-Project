using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
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
