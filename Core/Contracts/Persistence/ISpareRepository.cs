using Core.Domain.Entities;
using Core.Services.SpareService.Queries;

namespace Core.Contracts.Persistence
{
    public interface ISpareRepository
   {
      Task<bool> ExistOemCode(string oemCode);
      Task<bool> ExistSku(string sku);

      Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync(SpareFilter filter);
   }
}
