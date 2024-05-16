using Core.Enums;
using Core.Responses;

namespace Core.Services.SpareService.Queries
{
    public class SpareWithBrandToReturn : BaseResponse
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
