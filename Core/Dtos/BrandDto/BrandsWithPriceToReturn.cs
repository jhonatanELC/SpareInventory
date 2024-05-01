using Core.Dtos.SpareBrandDto;

namespace Core.Dtos.BrandDto
{
    public class BrandsWithPriceToReturn
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public List<SpareBrandToReturn> SpareBrands { get; set; }

    }
}
