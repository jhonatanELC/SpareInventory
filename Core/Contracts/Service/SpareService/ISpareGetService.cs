using Core.Services.SpareService.Queries;

namespace Core.Contracts.Service.SpareService
{
   public interface ISpareGetService
   {
      Task<SpareToReturn?> GetSpareById(Guid spareId);
      Task<IReadOnlyList<SpareToReturn>> GetSpares();

      Task<IReadOnlyList<SpareWithBrandToReturn>> GetSparesWithBrands(SpareFilter filter);
   }
}
