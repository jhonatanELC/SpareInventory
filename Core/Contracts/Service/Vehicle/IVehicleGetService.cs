using Core.Dtos.VehicleDto;

namespace Core.Contracts.Service.Vehicle
{
    public interface IVehicleGetService
    {
        Task<IReadOnlyList<VehicleToReturn>> GetVehicles();
    }
}
