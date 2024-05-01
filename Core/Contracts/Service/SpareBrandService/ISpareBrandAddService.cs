using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;

namespace Core.Contracts.Service.SpareBrandService
{
    public interface ISpareBrandAddService
    {
        Task<bool> AddBrandToSpare(SpareBrandToAdd spareBrandToAdd, PriceToAdd priceToAdd);

    }
}
