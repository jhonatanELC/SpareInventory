using AutoMapper;
using Core.Domain.Entities;
using Core.Dtos.SpareDto;

namespace Core.Profiles
{
    public class SparesProfile : Profile
    {
        public SparesProfile()
        {
            CreateMap<SpareToAdd, Spare>();
            CreateMap<Spare, SpareToReturn>();
            CreateMap<Spare, SpareWithBrandToReturn>();
            CreateMap<Spare, SpareWithBrandToReturn>();
        }
    }
}
