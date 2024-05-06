using Core.Enums;

namespace Core.Domain.Entities
{
    public class Spare
    {
        public Guid SpareId { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string? Comments { get; set; }
        public string? OemCode { get; set; } 
        public Group Group { get; set; }

        // Foreign key property
        public Guid? VehicleId { get; set; }

        // Navigation property 
        public Vehicle Vehicle { get; set; }
        public List<Brand> Brands { get; set; } = new List<Brand>();

        // Navigation property for the join table
        public List<SpareBrand> SpareBrands { get; set; } = new List<SpareBrand>();

        public Spare()
        {
            SpareId = Guid.NewGuid();
        }

    }
}
