using Core.Domain.Entities;

namespace Core.Contracts.Persistence
{
   public interface ISpareBrandRepository : IGenericRepository<SpareBrand>
   {
      Task<bool> ExistsBrandIdSpareIdAsync(Guid spareId, Guid brandId);
      Task<bool> ExistsSku(string sku);
      Task<SpareBrand?> GetSpareBrandWithPriceAsync(Guid spareBrandId);
   }
}
