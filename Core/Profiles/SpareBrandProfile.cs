using AutoMapper;
using Core.Domain.Entities;
using Core.Services.SpareBrandService;
using Core.Services.SpareService.Commands.Create;
using Core.Services.SpareService.Queries;

namespace Core.Profiles
{
    public class SpareBrandProfile : Profile
   {
      public SpareBrandProfile()
      {
         CreateMap<SpareBrandToAdd, SpareBrand>();
         CreateMap<SpareBrand, SpareBrandToReturn>();
         CreateMap<SpareWithBrandToAdd, SpareBrand>();
         CreateMap<SpareWithBrandToAdd, Spare>();
         CreateMap<SpareWithBrandToAdd, Price>();
      }

   }
}
