using LaLigaFans.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLigaFans.Infrastructure.Data.SeedDb.DataSeeds
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var data = new SeedData();

            builder
                .HasData(data.BarcaTShirt,
                         data.BarcaScarf,
                         data.BarcaBall,
                         data.BarcaCup,
                         data.BarcaBag,
                         data.BarcaKeychain,
                         data.RealTShirt,
                         data.RealScarf,
                         data.RealBall,
                         data.RealCup,
                         data.RealBag,
                         data.RealKeychain,
                         data.AtleticoTShirt,
                         data.AtleticoScarf,
                         data.AtleticoBall,
                         data.AtleticoCup,
                         data.AtleticoBag,
                         data.AtleticoKeychain,
                         data.ValenciaTShirt,
                         data.ValenciaScarf,
                         data.SevillaTShirt,
                         data.SevillaBall,
                         data.GironaTShirt,
                         data.AlavesTShirt);
        }
    }
}
