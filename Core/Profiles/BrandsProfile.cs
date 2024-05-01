using AutoMapper;
using Core.Domain.Entities;
using Core.Dtos.BrandDto;

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
