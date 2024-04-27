using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;

namespace Core.Contracts.Service.SpareBrand
{
    public interface ISpareBrandAddService
    {
        Task<bool> AddBrandToSpare(SpareBrandToAdd spareBrandToAdd, PriceToAdd priceToAdd);

    }
}
