using Core.Domain.Entities;

namespace Core.Contracts.Persistence
{
   public interface IVehicleRepository : IGenericRepository<Vehicle>
   {
      Task<bool> ExistBrandAndModel(string brand, string model);
   }
}
