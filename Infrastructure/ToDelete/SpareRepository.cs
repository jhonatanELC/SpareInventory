using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ToDelete
{
    public class SpareRepository : GenericRepository<Spare>, ISpareRepository
    {
        public SpareRepository(SpareInventoryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Spare>> GetAllSparesAsync()
        {
            return await _context.Spares.Include(s => s.Brands).ToListAsync();
        }

        public Task<IEnumerable<Spare>> GetSpareByBrandAsync(int Brandid)
        {
            throw new NotImplementedException();
        }

        public Task<Spare?> GetSpareByIdAsync(int EmployeeID)
        {
            throw new NotImplementedException();
        }
    }
}
