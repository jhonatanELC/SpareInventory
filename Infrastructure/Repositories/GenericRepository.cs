using Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly SpareInventoryDbContext _dbContext;

        public GenericRepository(SpareInventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public  void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);

            return t;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        // TODO 1: Implement the updateasync method 
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
