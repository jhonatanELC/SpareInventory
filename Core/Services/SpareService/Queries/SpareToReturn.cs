using Core.Enums;

namespace Core.Services.SpareService.Queries
{
   public class SpareToReturn
   {
      public Guid SpareId { get; set; }
      public string? Sku { get; set; }
      public string Description { get; set; }
      public string Comments { get; set; }
      public string OemCode { get; set; }
      public Group Group { get; set; }
   }
}
