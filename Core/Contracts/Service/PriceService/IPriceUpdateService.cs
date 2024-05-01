using Core.Dtos.PriceDto;
using Core.Domain.Entities;

namespace Core.Contracts.Service.PriceService
{
    public interface IPriceUpdateService
    {
        Task<Price?> UpdatePrice(PriceToAdd priceToUpdate, Guid spareBrandId);
    }
}
