using Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class SpareBrandRepository : GenericRepository<SpareBrandRepository>, ISpareBrandRepository
    {
        public SpareBrandRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> ExistsBrandIdSpareIdAsync(Guid spareId, Guid brandId)
        {
            return _dbContext.SpareBrands.AnyAsync(sb => sb.SpareId == spareId && sb.BrandId == brandId);
        }
    }
}
