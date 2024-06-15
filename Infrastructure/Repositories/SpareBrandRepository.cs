using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
   public class SpareBrandRepository : GenericRepository<SpareBrand>, ISpareBrandRepository
   {
      public SpareBrandRepository(SpareInventoryDbContext dbContext) : base(dbContext)
      {
      }

      public async Task<bool> ExistsBrandIdSpareIdAsync(Guid spareId, Guid brandId)
      {
         return await _dbContext.SpareBrands.AnyAsync(sb => sb.SpareId == spareId && sb.BrandId == brandId);
      }

      public async Task<bool> ExistsSku(string sku)
      {
         return await _dbContext.SpareBrands.AnyAsync(sb => sb.Sku == sku);
      }

      public async Task<SpareBrand?> GetSpareBrandWithPriceAsync(Guid spareBrandId)
      {
         SpareBrand? spareBrand = await _dbContext.SpareBrands
                                     .Include(sb => sb.Price)
                                     .FirstOrDefaultAsync(sb => sb.SpareBrandId == spareBrandId);

         return spareBrand;
      }
   }
}
