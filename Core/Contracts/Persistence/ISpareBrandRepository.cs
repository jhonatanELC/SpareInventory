using Core.Domain.Entities;

namespace Core.Contracts.Persistence
{
    public interface ISpareBrandRepository
    {
        Task<bool> ExistsBrandIdSpareIdAsync(Guid spareId, Guid brandId);

        Task<SpareBrand?> GetSpareBrandWithPriceAsync(Guid spareBrandId);
    }
}
