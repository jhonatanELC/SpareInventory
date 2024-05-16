namespace Core.Services.SpareService.Queries
{
    public class BrandsWithPriceToReturn
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public List<SpareBrandToReturn> SpareBrands { get; set; }

    }
}
