using Core.Enum;

namespace Core.Dtos.SpareDto
{
    public class SpareToAdd
    {
        public string Description { get; set; }
        public string Comments { get; set; } 
        public string Keyword { get; set; } 
        public string OemCode { get; set; } 
        public Group Group { get; set; }
        public Guid? VehicleId { get; set; }
    }
}
