using AutoMapper;
using Core.Domain.Entities;
using Core.Services.PriceService;
using Core.Services.SpareService.Commands.Create;
using Core.Services.SpareService.Queries;

namespace Core.Profiles
{
    public class PriceProfile : Profile
   {
      public PriceProfile()
      {
         CreateMap<PriceToAdd, Price>();
         CreateMap<Price, PriceToReturn>();
         CreateMap<SpareWithBrandToAdd, Price>();
      }
   }
}
