using Core.Dtos.PriceDto;

namespace Core.Dtos.SpareBrandDto
{
    public class SpareBrandToReturn
    {
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string? CodeByBrand { get; set; }
        public PriceToReturn Price { get; set; }

    }
}
