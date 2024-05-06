using Core.Domain.Entities;
using Core.Dtos.Filters;

namespace Core.Contracts.Persistence
{
    public interface ISpareRepository
    {
        Task<bool> ExistOemCode(string oemCode);

        Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync(SpareFilter filter);
    }
}
