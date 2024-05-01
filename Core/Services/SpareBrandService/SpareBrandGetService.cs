using Core.Contracts.Service.SpareBrandService;
using Core.Domain.Entities;

namespace Core.Services.SpareBrandService
{
    public class SpareBrandGetService : ISpareBrandGetService
    {   
        public SpareBrandGetService() 
        {

        }
        public Task<SpareBrand> GetSpareBrandWithPrice(Guid spareBrandId)
        {
            throw new NotImplementedException();
        }
    }
}
