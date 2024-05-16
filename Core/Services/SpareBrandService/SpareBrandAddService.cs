using AutoMapper;
using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareBrandService;
using Core.Domain.Entities;
using Core.Services.PriceService;

namespace Core.Services.SpareBrandService
{
    public class SpareBrandAddService : ISpareBrandAddService
    {
        private readonly IGenericRepository<SpareBrand> _genericRepository;
        private readonly IMapper _mapper;
        private readonly ISpareBrandRepository _spareBrandRepository;

        public SpareBrandAddService(IGenericRepository<SpareBrand> genericRepository, IMapper mapper, ISpareBrandRepository spareBrandRepository  )
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _spareBrandRepository = spareBrandRepository;
        }
        public async Task<bool> AddBrandToSpare(SpareBrandToAdd spareBrandToAdd, PriceToAdd priceToAdd)
        {   
            // Check if BrandId, SpareId already exists
            bool existsIds =  await _spareBrandRepository.ExistsBrandIdSpareIdAsync(spareBrandToAdd.SpareId, spareBrandToAdd.BrandId);


            if (existsIds)
            {
                throw new InvalidOperationException("BrandId y SpareId ya estan registrados");
            }

            // Mapping
            SpareBrand spareBrand = _mapper.Map<SpareBrand>(spareBrandToAdd);
            Price price = _mapper.Map<Price>(priceToAdd);

            // Add
            await _genericRepository.AddAsync(spareBrand);
            spareBrand.Price = price;

            return await _genericRepository.SaveChangesAsync();

        }
    }
}
