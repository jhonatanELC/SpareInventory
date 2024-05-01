using Core.Enum;

namespace Core.Dtos.PriceDto
{
    public class PriceToReturn
    {
        public Currency Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Igv { get; set; }
        public int ProfitMargin { get; set; }
    }
}
