using MediatR;

namespace Core.Features.Vehicles.Commands.CreateVehicle
{
   public class CreateVehicleCommand : IRequest<Guid?>
   {
      public string Brand { get; set; }
      public string? Model { get; set; }
      public int? Year { get; set; }
   }
}
