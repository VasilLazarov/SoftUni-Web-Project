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
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
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
