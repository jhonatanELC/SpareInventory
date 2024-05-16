using AutoMapper;
using Core.Domain.Entities;
using Core.Services.SpareService.Commands.Create;
using Core.Services.SpareService.Queries;

namespace Core.Profiles
{
   public class SparesProfile : Profile
   {
      public SparesProfile()
      {
         CreateMap<SpareToAdd, Spare>();
         CreateMap<Spare, SpareToReturn>();
         CreateMap<Spare, SpareWithBrandToReturn>();

         // All this mapping is to get SpareVmToReturn
         CreateMap<Spare, SpareVmToReturn>()
            .ForMember(dest => dest.spare, opt => opt.MapFrom(src => src));
         CreateMap<Spare, SpareDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brands.Last()));
         CreateMap<Brand, BrandDto>();


      }
   }
}
