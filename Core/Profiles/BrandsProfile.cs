using AutoMapper;
using Core.Domain.Entities;
using Core.Features.Brands.Commands.CreateBrand;
using Core.Features.Brands.Queries.GetBrands;

namespace Core.Profiles
{
   public class BrandsProfile : Profile
   {
      public BrandsProfile()
      {
         CreateMap<Brand, BrandToReturn>();
         CreateMap<Brand, BrandResponse>();
        }
   }
}
