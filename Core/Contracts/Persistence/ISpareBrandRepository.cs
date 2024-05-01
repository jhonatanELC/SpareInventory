namespace Core.Contracts.Persistence
{
    public interface ISpareBrandRepository
    {
        Task<bool> ExistsBrandIdSpareIdAsync(Guid spareId, Guid brandId);
    }
}
