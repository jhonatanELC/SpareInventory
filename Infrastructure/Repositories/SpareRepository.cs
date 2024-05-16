﻿using Core.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Enums;
using Core.Services.SpareService.Queries;
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

      public async Task<bool> ExistSku(string sku)
      {
         return await _dbContext.Spares.AnyAsync(s => s.Sku == sku);
      }

      public async Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync(SpareFilter filter)
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

         // Filtering by OemCode
         if (!string.IsNullOrWhiteSpace(filter.filterByOemCode))
         {
            filter.filterByOemCode = filter.filterByOemCode.Trim();

            collection = collection
                .Where(s => s.OemCode == filter.filterByOemCode);
         }

         // Search by Sku
         if (!string.IsNullOrWhiteSpace(filter.searchrBySku))
         {
            filter.searchrBySku = filter.searchrBySku.Trim();

            collection = collection
                .Where(s => s.Sku.Contains(filter.searchrBySku));
         }

         // Search 
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
