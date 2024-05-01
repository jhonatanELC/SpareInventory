using Core.Contracts.Persistence;
using Core.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
