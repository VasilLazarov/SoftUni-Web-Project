using LaLigaFans.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.UnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static LaLigaFansDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<LaLigaFansDbContext>()
                    .UseInMemoryDatabase("LaLigaFansInMemoryDb" 
                        + Guid.NewGuid().ToString())
                    .Options;

                return new LaLigaFansDbContext(dbContextOptions, false);
            }
        }
    }
}
