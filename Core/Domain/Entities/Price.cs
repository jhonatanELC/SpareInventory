using Core.Enums;

namespace Core.Domain.Entities
{
    public class Price
    {
        public Guid PriceId { get; set; }
        public Currency Currency  { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Igv { get; set; }
        public int ProfitMargin { get; set; }

        // FK
        public Guid SpareBrandId { get; set; }

        // Navigation Property
        public SpareBrand SpareBrand { get; set; }

   
    }
}
