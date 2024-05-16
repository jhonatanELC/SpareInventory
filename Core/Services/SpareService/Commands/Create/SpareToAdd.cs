using Core.Enums;

namespace Core.Services.SpareService.Commands.Create
{
    public class SpareToAdd
    {
        public string Description { get; set; }
        public string? Comments { get; set; }
        public string? OemCode { get; set; }
        public string Sku { get; set; }
        public Group Group { get; set; }
        public Guid? VehicleId { get; set; }
    }
}
