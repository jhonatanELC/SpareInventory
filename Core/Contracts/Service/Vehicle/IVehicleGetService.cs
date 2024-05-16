using Core.Services.VehicleService.Commands.Create;

namespace Core.Contracts.Service.Vehicle
{
    public interface IVehicleGetService
    {
        Task<IReadOnlyList<VehicleToReturn>> GetVehicles();
    }
}
