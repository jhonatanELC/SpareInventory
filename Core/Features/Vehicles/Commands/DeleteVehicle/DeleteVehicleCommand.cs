using MediatR;

namespace Core.Features.Vehicles.Commands.DeleteVehicle
{
   public class DeleteVehicleCommand : IRequest<bool>
   {
      public Guid VehicleId { get; set; }
   }
}
