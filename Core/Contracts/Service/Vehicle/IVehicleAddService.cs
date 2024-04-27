using Core.Dtos.VehicleDto;

namespace Core.Contracts.Service.Vehicle
{
    public interface IVehicleAddService
    {
        Task<VehicleToReturn> AddVehicle(VehicleToAdd vehicleToAdd);

    }
}
