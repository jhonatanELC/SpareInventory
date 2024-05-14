using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;
using Core.Dtos.SpareDto;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Models
{
   [Bind]
   public class SpareToAddVm
   {
      // Spare
      public string Description { get; set; }
      public string? Comments { get; set; }
      public string? OemCode { get; set; }
      public string Sku { get; set; }
      public Group Group { get; set; }
      //public Guid? VehicleId { get; set; }

      // Price
      public Currency Currency { get; set; }
      public decimal UnitPrice { get; set; }
      public int Igv { get; set; }
      public int ProfitMargin { get; set; }
      public decimal SellPrice { get; set; }

      // Brand
      public Guid BrandId { get; set; }

      // SpareBrand
      public string? CodeByBrand { get; set; }
      public string Unit { get; set; }



      public SpareToAdd GetSpareToAdd()
      {
         SpareToAdd spare = new SpareToAdd();

         spare.Description = Description;
         spare.Comments = Comments;
         spare.OemCode = OemCode;
         spare.Sku = Sku;
         spare.Group = Group;
         //spare.VehicleId = VehicleId;

         return spare;
      }

      public SpareBrandToAdd GetSpareBrandToAdd()
      {
         SpareBrandToAdd spareBrand = new SpareBrandToAdd();

         spareBrand.CodeByBrand = CodeByBrand;
         spareBrand.Unit = Unit;

         return spareBrand;
      }

      public PriceToAdd GetPriceToAdd()
      {
         PriceToAdd price = new PriceToAdd();

         price.UnitPrice = UnitPrice;
         price.SellPrice = SellPrice;
         price.ProfitMargin = ProfitMargin;
         price.Currency = Currency;
         price.Igv = Igv;

         return price;
      }

   }


}
