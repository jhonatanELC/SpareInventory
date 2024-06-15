using AutoMapper;
using Core.Domain.Entities;
using Core.Features.Spares.Commands.CreateSpare;
using Core.Features.Spares.Queries.GetSpareWithBrands;

namespace Core.Profiles
{
    public class SparesProfile : Profile
   {
      public SparesProfile()
      {   
         CreateMap<CreateSpareCommand, Spare>();
         CreateMap<CreateSpareCommand, Price>();
         CreateMap<CreateSpareCommand, SpareBrand>();


         // All this mapping is to get SpareVmToReturn
         CreateMap<Spare, SpareVmToReturn>()
            .ForMember(dest => dest.spare, opt => opt.MapFrom(src => src));
         CreateMap<Spare, SpareDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brands.Last()));
         CreateMap<Brand, BrandDto>();


      }
   }
}
