using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.PriceService;
using Core.Domain.Entities;
using Core.Dtos.PriceDto;

namespace Core.Services.PriceService
{
    public class PriceUpdateService : IPriceUpdateService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<SpareBrand> _genericRepository;
        private readonly ISpareBrandRepository _spareBrandRepository;

        public PriceUpdateService(IMapper mapper, IGenericRepository<SpareBrand> genericRepository, ISpareBrandRepository spareBrandRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _spareBrandRepository = spareBrandRepository;
        }
        public async Task<Price?> UpdatePrice(PriceToAdd priceToUpdate, Guid spareBrandId)
        {   

            SpareBrand? spareBrand = await _spareBrandRepository.GetSpareBrandWithPriceAsync(spareBrandId);

            if (spareBrand == null) return null;

            Price price = spareBrand.Price;

            _mapper.Map(priceToUpdate, price);

            await _genericRepository.SaveChangesAsync();

            return price;
        }
    }
}
