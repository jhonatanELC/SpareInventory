using Core.Dtos.BrandDto;
using Core.Enums;

namespace Core.Dtos.SpareDto
{
    public class SpareWithBrandToReturn
    {
        public Guid SpareId { get; set; }
        public string? Sku { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string OemCode { get; set; }
        public Group Group { get; set; }
        public List<BrandsWithPriceToReturn> Brands { get; set; }

    }
}
