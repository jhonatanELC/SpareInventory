using Core.Contracts.Persistence;
using Core.Contracts.Service.SpareBrandService;
using Core.Domain.Entities;

namespace Core.Services.SpareBrandService
{   
    // TODO 3: Not Implemented Yet
    public class SpareBrandUpdateSellPriceService : ISpareBrandUpdateSellPriceService
    {
        private readonly IGenericRepository<Price> _genericRepository;

        public SpareBrandUpdateSellPriceService(IGenericRepository<Price> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task UpdateSellPrices()
        {
            IQueryable collection = _genericRepository.GetDbSet(); 

            throw new NotImplementedException();
        }
    }
}
