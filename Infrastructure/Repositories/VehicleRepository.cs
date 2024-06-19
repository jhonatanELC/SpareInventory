using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
   public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
   {
      public VehicleRepository(SpareInventoryDbContext dbContext) : base(dbContext)
      {
      }

      public async Task<bool> ExistBrandAndModel(string brand, string model)
      {
         return await _dbContext.Vehicles.AnyAsync(v => v.Brand == brand && v.Model == model);
      }
   }
}
