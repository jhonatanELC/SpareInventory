using Core.Domain.Entities;

namespace Infrastructure.ToDelete
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(SpareInventoryDbContext context) : base(context)
        {
        }
    }
}
