using Core.Contracts.Persistence;
using Core.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
