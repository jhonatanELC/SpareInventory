using AutoMapper;
using Core.Domain.Entities;
using Core.Services.BrandService.Commands.Create;
using Core.Services.SpareService.Queries;

namespace Core.Profiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            CreateMap<Brand, BrandToReturn>();
            CreateMap<Brand, BrandsWithPriceToReturn>();
        }
    }
}
