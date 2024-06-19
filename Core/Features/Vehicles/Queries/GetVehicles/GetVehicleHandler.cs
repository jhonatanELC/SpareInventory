using AutoMapper;
using Core.Contracts.Persistence;
using Core.Domain.Entities;
using MediatR;

namespace Core.Features.Vehicles.Queries.GetVehicles
{
   public class GetVehicleHandler : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleResponse>>
   {
      private readonly IVehicleRepository _vehicleRepository;
      private readonly IMapper _mapper;


      public GetVehicleHandler(IVehicleRepository vehicleRepository , IMapper mapper)
      {
         _vehicleRepository = vehicleRepository;
         _mapper = mapper;
      }
      public async Task<IEnumerable<VehicleResponse>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
      {
         IEnumerable<Vehicle> vehicles = await _vehicleRepository.ListAllAsync();

         return (_mapper.Map<IEnumerable<VehicleResponse>>(vehicles));
      }
   }
}
