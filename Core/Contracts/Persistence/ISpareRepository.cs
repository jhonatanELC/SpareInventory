using Core.Domain.Entities;
using Core.Features.Spares.Queries.GetSparesWithBrands;


namespace Core.Contracts.Persistence
{
    public interface ISpareRepository : IGenericRepository<Spare>
   {
      Task<bool> ExistOemCode(string oemCode);
      Task<Spare?> GetSpareByOemCode(string oemCode);
      Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync(GetSparesWithBrandsQuery filter);
      Task<Spare?> GetSpareWithBrands(Guid spareId);
   }
}
