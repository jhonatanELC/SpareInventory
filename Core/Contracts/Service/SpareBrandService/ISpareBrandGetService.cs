using Core.Domain.Entities;

namespace Core.Contracts.Service.SpareBrandService
{
    public interface ISpareBrandGetService
    {
        Task<SpareBrand> GetSpareBrandWithPrice(Guid spareBrandId);
    }
}
