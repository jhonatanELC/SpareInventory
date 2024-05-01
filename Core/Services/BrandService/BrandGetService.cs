using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.Brand;
using Core.Domain.Entities;
using Core.Dtos.BrandDto;

namespace Core.Services.BrandService
{
    internal class BrandGetService : IBrandGetService
    {
        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public BrandGetService(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<BrandToReturn?> GetBrandById(Guid brandId)
        {
            Brand? brand =  await _genericRepository.GetByIdAsync(brandId);

            if(brand == null) return null;

            return _mapper.Map<BrandToReturn>(brand);
        }

        public async Task<IReadOnlyList<BrandToReturn>> GetBrands()
        {
            IReadOnlyList<Brand> brands = await _genericRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<BrandToReturn>>(brands);
        }
    }
}
