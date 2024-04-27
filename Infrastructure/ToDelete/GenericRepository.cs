using Microsoft.EntityFrameworkCore;


namespace Infrastructure.ToDelete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //The following variable is going to hold the EFCoreDbContext instance
        protected readonly SpareInventoryDbContext _context;
        //The following Variable is going to hold the DbSet Entity
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(SpareInventoryDbContext context)
        {
            //we are initializing the context object and DbSet variable
            _context = context;
            //Whatever Entity name we specify while creating the instance of GenericRepository
            //That Entity name  will be stored in the DbSet<T> variable
            _dbSet = context.Set<T>();
        }
        //This method will return all the Records from the table
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        //This method will return the specified record from the table based on the Primary Key Column
        public async Task<T?> GetByIdAsync(object Id)
        {
            return await _dbSet.FindAsync(Id);
        }
        //This method will Insert one object into the table
        public async Task InsertAsync(T Entity)
        {
            //It will mark the Entity state as Added
            await _dbSet.AddAsync(Entity);
        }
        //This method is going to update an Existing Entity
        public async Task UpdateAsync(T Entity)
        {
            //It will mark the Entity state as Modified
            _dbSet.Update(Entity);
        }
        //This method is going to remove an existing record from the table
        public async Task DeleteAsync(object Id)
        {
            //First, fetch the record from the table
            var entity = await _dbSet.FindAsync(Id);
            if (entity != null)
            {
                //This will mark the Entity State as Deleted
                _dbSet.Remove(entity);
            }
        }
        //This method will make the changes permanent in the database
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
