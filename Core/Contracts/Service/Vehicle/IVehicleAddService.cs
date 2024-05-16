using Core.Services.VehicleService.Commands.Create;

namespace Core.Contracts.Service.Vehicle
{
    public interface IVehicleAddService
    {
        Task<VehicleToReturn> AddVehicle(VehicleToAdd vehicleToAdd);

    }
}
