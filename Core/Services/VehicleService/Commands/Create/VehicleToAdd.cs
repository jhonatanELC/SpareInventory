namespace Core.Services.VehicleService.Commands.Create
{
    public class VehicleToAdd
    {
        public string Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}
