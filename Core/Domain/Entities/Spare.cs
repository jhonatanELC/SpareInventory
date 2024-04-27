using Core.Enum;

namespace Core.Domain.Entities
{
    public class Spare
    {
        public Guid SpareId { get; set; }
        public string? Sku { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Keyword { get; set; } = string.Empty;
        public string OemCode { get; set; } = string.Empty;
        public Group Group { get; set; }

        // Foreign key property
        public Guid? VehicleId { get; set; }

        // Navigation property 
        public Vehicle Vehicle { get; set; }
        public List<Brand> Brands { get; set; } = new List<Brand>();

        // Navigation property for the join table
        public List<SpareBrand> SpareBrands { get; set; } = new List<SpareBrand>();

    }
}
