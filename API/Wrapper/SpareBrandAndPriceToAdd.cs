using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;

namespace API.Wrapper
{
    public class SpareBrandAndPriceToAdd
    {
        public SpareBrandToAdd SpareBrandToAdd { get; set; }
        public PriceToAdd PriceToAdd { get; set; }
    }
}
