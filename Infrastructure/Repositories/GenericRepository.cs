using Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly SpareInventoryDbContext _dbContext;

        public GenericRepository(SpareInventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetDbSet()
        {
            return _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public  void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> ExistsEntityAsync( Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);

            return t;
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
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
