﻿namespace Core.Domain.Entities
{
   public class SpareBrand
   {
      public Guid SpareBrandId { get; set; }
      public int Quantity { get; set; }
      public string Unit { get; set; }
      public string? CodeByBrand { get; set; }
      public string Sku { get; set; }


      // FK
      public Guid SpareId { get; set; }
      public Guid BrandId { get; set; }

      // Navigation properties
      public Spare Spare { get; set; }
      public Brand Brand { get; set; }
      public Price Price { get; set; }
   }
}
