using Core.Contracts.Persistence;
using Core.Domain.Entities;


namespace Infrastructure.Repositories
{
    internal class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(SpareInventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
