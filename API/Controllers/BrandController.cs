using Core.Features.Brands.Commands.CreateBrand;
using Core.Features.Brands.Commands.DeleteBrand;
using Core.Features.Brands.Queries.GetBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [Route("api/brands")]
   [ApiController]
   public class BrandController : Controller
   {
      private readonly IMediator _mediator;

      public BrandController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands()
      {
         var response = await _mediator.Send(new GetBrandsQuery());

         return Ok(response);
      }


      [HttpPost("{brandName}")]
      public async Task<ActionResult<BrandToReturn>> AddBrand(string brandName)
      {
         var brandToReturn = await _mediator.Send(new CreateBrandCommand() { brandName = brandName });

         return Ok(brandToReturn);
      }

      [HttpDelete("{brandId}")]
      public async Task<IActionResult> DeleteBrand(Guid brandId)
      {
         bool response = await _mediator.Send(new DeleteBrandCommand() { brandId = brandId });

         if (!response) return NotFound();

         return NoContent();
      }

   }
}
