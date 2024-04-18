namespace Core.Domain.Entities
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship
        public List<Spare> Spares { get; set; }

        // Navigation property for the join table
        public List<SpareBrand> SpareBrands { get; set; } = new List<SpareBrand>();

    }
}
