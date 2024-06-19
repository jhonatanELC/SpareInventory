using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Vehicles.Commands.DeleteVehicle
{
   public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, bool>
   {
      private readonly IVehicleRepository _vehicleRepository;

      public DeleteVehicleHandler(IVehicleRepository vehicleRepository)
      {
         _vehicleRepository = vehicleRepository;
      }
      public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
      {  
         Vehicle? vehicle = await  _vehicleRepository.GetByIdAsync(request.VehicleId);
         if (vehicle ==null) return false;
         
         _vehicleRepository.Delete(vehicle);
         return await _vehicleRepository.SaveChangesAsync();
      }
   }
}
