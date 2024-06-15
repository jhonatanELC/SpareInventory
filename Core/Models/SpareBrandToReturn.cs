using Core.Enums;

namespace Core.Models
{
   public class SpareBrandToReturn
   {
      public Guid BrandId { get; set; }
      public string Name { get; set; }
      public string Sku { get; set; }
      public int Quantity { get; set; }
      public string Unit { get; set; }
      public string? CodeByBrand { get; set; }
      public Currency Currency { get; set; }
      public decimal UnitPrice { get; set; }
      public decimal SellPrice { get; set; }
      public int Igv { get; set; }
      public int ProfitMargin { get; set; }
   }
}
