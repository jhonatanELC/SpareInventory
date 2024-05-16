using Core.Domain.Entities;
using Core.Services.PriceService;

namespace Core.Contracts.Service.PriceService
{
    public interface IPriceUpdateService
    {
        Task<Price?> UpdatePrice(PriceToAdd priceToUpdate, Guid spareBrandId);
    }
}
