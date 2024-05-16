using Core.Services.PriceService;
using Core.Services.SpareBrandService;

namespace API.Wrapper
{
    public class SpareBrandAndPriceToAdd
    {
        public SpareBrandToAdd SpareBrandToAdd { get; set; }
        public PriceToAdd PriceToAdd { get; set; }
    }
}
