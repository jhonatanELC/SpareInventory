using Core.Enum;

namespace Core.Dtos.PriceDto
{
    public class PriceToAdd
    {
        // Price
        public Currency Currency { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
