using MediatR;

namespace Core.Features.Vehicles.Queries.GetVehicles
{
   public class GetVehiclesQuery : IRequest<IEnumerable<VehicleResponse>>
   {
   }
}
