using Core.Domain.Entities;

namespace Core.Contracts.Persistence
{
    public interface ISpareRepository
    {
        Task<bool> ExistOemCode(string oemCode);

        Task<IReadOnlyList<Spare>> GetSparesWithBrandsAsync();
    }
}
