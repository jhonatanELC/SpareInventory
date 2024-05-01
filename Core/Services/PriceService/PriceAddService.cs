using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.PriceService;
using Core.Domain.Entities;
using Core.Dtos.PriceDto;

namespace Core.Services.PriceService
{
    public class PriceAddService : IPriceAddService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Price> _genericRepository;

        public PriceAddService(IMapper mapper, IGenericRepository<Price> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<bool> AddPrice(PriceToAdd priceToAdd, Guid spareBrandId)
        {
            Price price = _mapper.Map<Price>(priceToAdd);
            price.SpareBrandId = spareBrandId;

            await _genericRepository.AddAsync(price);
            return await _genericRepository.SaveChangesAsync();

        }
    }
}
