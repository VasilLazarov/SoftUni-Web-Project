using Microsoft.EntityFrameworkCore;

namespace LaLigaFans.Infrastructure.Data.Comman
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(DbContext _context)
        {
            context = _context;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return GetDbSet<T>();
        }
        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return GetDbSet<T>()
                    .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await GetDbSet<T>().AddAsync(entity);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);
            if(entity != null)
            {
                GetDbSet<T>().Remove(entity);
            }
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await GetDbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }


        private DbSet<T> GetDbSet<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}
