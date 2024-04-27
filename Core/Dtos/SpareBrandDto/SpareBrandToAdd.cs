namespace Core.Dtos.SpareBrandDto
{
    public class SpareBrandToAdd
    {
        public int Quantity { get; set; }
        public string? CodeByBrand { get; set; }

        // FKs
        public Guid SpareId { get; set; }
        public Guid BrandId { get; set; }
    }
}
