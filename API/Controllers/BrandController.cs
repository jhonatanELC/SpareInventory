using Core.Contracts.Service.Brand;
using Core.Dtos.BrandDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandAddService _brandAddService;

        public BrandController(IBrandAddService brandAddService)
        {
            _brandAddService = brandAddService;
        }


        [HttpPost]
        public async Task<ActionResult<BrandToReturn>> AddBrand(string brandName)
        {
            var brandToReturn = await _brandAddService.AddBrand(brandName);

            return Ok(brandToReturn);
        }

    }
}
