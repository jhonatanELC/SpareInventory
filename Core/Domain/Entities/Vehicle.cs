namespace Core.Domain.Entities
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }

        // Navigation property 
        public List<Spare> Spares { get; set; }

    }
}
