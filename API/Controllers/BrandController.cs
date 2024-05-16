using Core.Contracts.Service.Brand;
using Core.Services.BrandService.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandAddService _brandAddService;
        private readonly IBrandGetService _brandGetService;

        public BrandController(IBrandAddService brandAddService, IBrandGetService brandGetService)
        {
            _brandAddService = brandAddService;
            _brandGetService = brandGetService;
        }


        [HttpPost]
        public async Task<ActionResult<BrandToReturn>> AddBrand(string brandName)
        {
            var brandToReturn = await _brandAddService.AddBrand(brandName);

            return Ok(brandToReturn);
        }

        [HttpGet("{brandId}", Name = "GetBrand")]
        public async Task<ActionResult<BrandToReturn>> GetBrand(Guid brandId)
        {
            BrandToReturn? brand = await _brandGetService.GetBrandById(brandId);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandToReturn>>> GetAllBrands()
        {
            IReadOnlyList<BrandToReturn> brands = await _brandGetService.GetBrands();

            return Ok(brands);
        }

    }
}
