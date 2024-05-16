using Core.Services.PriceService;
using Core.Services.SpareBrandService;

namespace Core.Contracts.Service.SpareBrandService
{
    public interface ISpareBrandAddService
    {
        Task<bool> AddBrandToSpare(SpareBrandToAdd spareBrandToAdd, PriceToAdd priceToAdd);

    }
}
