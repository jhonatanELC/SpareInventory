using System.Linq.Expressions;

namespace Core.Contracts.Persistence
{
    public interface IGenericRepository<T> where T: class
    {   
        /// <summary>
        /// Gets the entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An entity</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Checks if the entity exists by Id
        /// </summary>
        /// <param name="id">An expression that compares the Id of the entity</param>
        /// <returns></returns>
        Task<bool> ExistsEntityAsync(Expression<Func<T, bool>> predicate );

        /// <summary>
        /// Get a list of entities 
        /// </summary>
        /// <returns>A IReadOnlyList</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        void DeleteAsync(T entity);

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Gets the DbSet as IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetDbSet();

    }
}
