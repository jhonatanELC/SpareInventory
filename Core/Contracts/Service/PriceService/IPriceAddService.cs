using Core.Dtos.BrandDto;
using Core.Dtos.PriceDto;

namespace Core.Contracts.Service.PriceService
{
    public interface IPriceAddService
    {
        /// <summary>
        /// Adds a price to an spareBrand table
        /// </summary>
        /// <param name="price"></param>
        /// <param name="spareBrandId"></param>
        /// <returns></returns>
        Task<bool> AddPrice(PriceToAdd price, Guid spareBrandId);

    }
}
