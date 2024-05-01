using Core.Domain.Entities;

namespace Core.Contracts.Service.SpareService
{
    public interface ISpareDeleteService
    {
        Task<Spare?> DeleteSpare(Guid spareId);
    }
}
