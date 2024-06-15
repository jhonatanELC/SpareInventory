using Core.Domain.Entities;
using Core.Models;

namespace Core.Extentions
{
   public static class SpareBrandResponse
   {
      public static SpareBrandToReturn ToSpareBrandResponse(this SpareBrand spareBrand)
      {
         return new SpareBrandToReturn()
         {
            BrandId = spareBrand.Brand.BrandId,
            Name = spareBrand.Brand.Name,
            Sku = spareBrand.Sku,
            Quantity = spareBrand.Quantity,
            Unit = spareBrand.Unit,
            CodeByBrand = spareBrand.CodeByBrand,
            Currency = spareBrand.Price.Currency,
            UnitPrice = spareBrand.Price.UnitPrice,
            SellPrice = spareBrand.Price.SellPrice,
            ProfitMargin = spareBrand.Price.ProfitMargin,
            Igv = spareBrand.Price.Igv
         };
      }


   }
}
