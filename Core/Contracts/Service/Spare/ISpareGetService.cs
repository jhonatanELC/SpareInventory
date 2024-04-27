using Core.Dtos.SpareDto;

namespace Core.Contracts.Service.Spare
{
    public interface ISpareGetService
    {
        Task<SpareToReturn?> GetSpareById(Guid spareId);
        Task<IReadOnlyList<SpareToReturn>> GetSpares();
    }
}
