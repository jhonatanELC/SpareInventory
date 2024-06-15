using Core.Enums;
using MediatR;

namespace Core.Features.Spares.Commands.CreateSpare
{
   public class CreateSpareCommand : IRequest<SpareVmToReturn>
   {
      // Spare
      public string Description { get; set; }
      public string? Comments { get; set; }
      public string? OemCode { get; set; }
      public Group Group { get; set; }
      public Guid? VehicleId { get; set; }

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
      public string Sku { get; set; }

   }
}
