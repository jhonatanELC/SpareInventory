namespace Core.Services.VehicleService.Commands.Create
{
    public class VehicleToReturn
    {
        public Guid VehicleId { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}
