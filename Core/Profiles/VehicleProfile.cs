using AutoMapper;
using Core.Domain.Entities;
using Core.Services.VehicleService.Commands.Create;

namespace Core.Profiles
{
    public  class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleToAdd, Vehicle>();
            CreateMap<Vehicle, VehicleToReturn>();
        }
    }
}
