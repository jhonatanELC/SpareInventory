namespace Core.Features.Vehicles.Queries.GetVehicles
{
   public class VehicleResponse
   {
      public Guid VehicleId { get; set; }
      public string Brand { get; set; }
      public string? Model { get; set; }
      public int? Year { get; set; }
   }
}
