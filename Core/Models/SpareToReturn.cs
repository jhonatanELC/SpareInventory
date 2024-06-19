using Core.Enums;

namespace Core.Models
{
   public class SpareToReturn
   {
      public Guid SpareId { get; set; }
      public string Description { get; set; }
      public string Comments { get; set; }
      public string OemCode { get; set; }
      public Group Group { get; set; }
      public Guid? VehicleId { get; set; }
      public List<SpareBrandToReturn> Brands { get; set; }
   }
}
