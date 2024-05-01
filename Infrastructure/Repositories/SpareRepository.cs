using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SpareRepository : GenericRepository<Spare>, ISpareRepository
    {
        public SpareRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<bool> ExistOemCode(string oemCode)
        {
            return await _dbContext.Spares.AnyAsync(s => s.OemCode == oemCode);
        }

        public async Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync()
        {
            return await _dbContext.Spares.Include(s => s.Brands)
                .ThenInclude(b => b.SpareBrands)
                .ThenInclude(sb => sb.Price)
                .ToListAsync();
        }
    }
}
