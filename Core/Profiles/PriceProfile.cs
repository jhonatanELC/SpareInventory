using AutoMapper;
using Core.Domain.Entities;
using Core.Dtos.PriceDto;

namespace Core.Profiles
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PriceToAdd, Price>();
            CreateMap<Price, PriceToReturn>();            
        }
    }
}
