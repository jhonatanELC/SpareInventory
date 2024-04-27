using AutoMapper;
using Core.Domain.Entities;
using Core.Dtos.SpareBrandDto;

namespace Core.Profiles
{
    public class SpareBrandProfile : Profile
    {
        public SpareBrandProfile()
        {
            CreateMap<SpareBrandToAdd, SpareBrand>();
        }

    }
}
