using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.Brand;
using Core.Domain.Entities;

namespace Core.Services.BrandService.Commands.Create
{
    public class BrandAddService : IBrandAddService
    {
        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public BrandAddService(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<BrandToReturn> AddBrand(string brandName)
        {
            Brand brand = new();
            brand.Name = brandName;

            await _genericRepository.AddAsync(brand);
            await _genericRepository.SaveChangesAsync();

            BrandToReturn brandToReturn = _mapper.Map<BrandToReturn>(brand);

            return brandToReturn;
        }
    }
}
