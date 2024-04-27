using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareBrand;
using Core.Domain.Entities;
using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;

namespace Core.Services.SpareBrandService
{
    public class SpareBrandAddService : ISpareBrandAddService
    {
        private readonly IGenericRepository<SpareBrand> _genericRepository;
        private readonly IMapper _mapper;

        public SpareBrandAddService(IGenericRepository<SpareBrand> genericRepository, IMapper mapper )
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddBrandToSpare(SpareBrandToAdd spareBrandToAdd, PriceToAdd priceToAdd)
        {
            SpareBrand spareBrand =  _mapper.Map<SpareBrand>(spareBrandToAdd);
            Price price = _mapper.Map<Price>(priceToAdd);

            await _genericRepository.AddAsync(spareBrand);
            spareBrand.Price = price;

            return await _genericRepository.SaveChangesAsync();
        }
    }
}
