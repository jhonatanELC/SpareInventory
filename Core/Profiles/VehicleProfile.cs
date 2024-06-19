using AutoMapper;
using Core.Domain.Entities;
using Core.Features.Vehicles.Queries.GetVehicles;

namespace Core.Profiles
{
   public class VehicleProfile : Profile
   {
      public VehicleProfile()
      {
         CreateMap<Vehicle, VehicleResponse>();
      }
   }
}
