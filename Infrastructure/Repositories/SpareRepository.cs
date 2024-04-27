using Core.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SpareRepository : GenericRepository<Spare>
    {
        public SpareRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
