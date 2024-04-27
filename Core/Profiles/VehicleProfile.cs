using AutoMapper;
using Core.Domain.Entities;
using Core.Dtos.VehicleDto;

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
