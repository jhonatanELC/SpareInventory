using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Enums;
using Core.Features.Spares.Queries.GetSparesWithBrands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
   public class SpareRepository : GenericRepository<Spare>, ISpareRepository
   {
      public SpareRepository(SpareInventoryDbContext dbContext) : base(dbContext)
      {

      }
      public async Task<bool> ExistOemCode(string oemCode)
      {
         return await _dbContext.Spares.AnyAsync(s => s.OemCode == oemCode);
      }

      public async Task<Spare?> GetSpareByOemCode(string oemCode)
      {
         return await _dbContext.Spares.FirstOrDefaultAsync(s => s.OemCode == oemCode);
      }

      public async Task<Spare?> GetSpareWithBrands(Guid spareId)
      {
         Spare? spare = await _dbContext.Spares               
               .Include(b => b.SpareBrands)
               .ThenInclude(sb => sb.Brand)
               .Include(s => s.SpareBrands)
               .ThenInclude(sb => sb.Price)
               .AsNoTracking()
               .FirstOrDefaultAsync(s => s.SpareId == spareId);

         return spare;
      }

      public async Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync(GetSparesWithBrandsQuery filter)
      {
         IQueryable<Spare> collection = _dbContext.Spares;

         collection = collection.Include(s => s.Brands)
             .ThenInclude(b => b.SpareBrands)
             .ThenInclude(sb => sb.Price);


         // Filtering by Group
         if (!string.IsNullOrWhiteSpace(filter.filterByGroup))
         {
            filter.filterByGroup = filter.filterByGroup.Trim();

            // TODO 4: review the out syntaxt
            // Parsing the string to enum
            bool parse = Enum.TryParse<Group>(filter.filterByGroup, true, out Group result);

            collection = collection
                    .Where(s => s.Group == result);
         }

         // Search by OemCode
         if (!string.IsNullOrWhiteSpace(filter.searchByOemCode))
         {
            filter.searchByOemCode = filter.searchByOemCode.Trim();

            collection = collection
                .Where(s => s.OemCode == filter.searchByOemCode);
         }

         // Search by Sku
         if (!string.IsNullOrWhiteSpace(filter.searchrBySku))
         {
            filter.searchrBySku = filter.searchrBySku.Trim();

            collection = collection
               .Where(s => s.SpareBrands.Any(sb => sb.Sku.Contains(filter.searchrBySku)));

         }

         // Search by description
         if (!string.IsNullOrWhiteSpace(filter.searchByDescription))
         {
            filter.searchByDescription = filter.searchByDescription.Trim();

            collection = collection
                .Where(s => s.Description.Contains(filter.searchByDescription));
         }

         var totalItems = await collection.CountAsync();

         var collectionToReturn = await collection
             .OrderBy(s => s.Group)
             .ToListAsync();

         return collectionToReturn;
      }
   }
}
