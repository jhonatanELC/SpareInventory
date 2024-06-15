using Core.Features.Spares.Commands.CreateSpare;
using Core.Features.Spares.Queries.GetSparesWithBrands;
using Core.Features.Spares.Queries.GetSpareWithBrands;
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [Route("api/sparebrand")]
   [ApiController]
   public class SpareBrandController : Controller
   {
      private readonly IMediator _mediator;

      public SpareBrandController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost]
      public async Task<ActionResult<SpareVmToReturn>> AddSpareWithBrand(CreateSpareCommand createSpareCommand)
      {
         SpareVmToReturn spare = await _mediator.Send(createSpareCommand);

         return Ok(spare);
      }

      [HttpGet("{spareId}", Name = "GetSpare")]
      public async Task<ActionResult<SpareToReturn>> GetSpareWithBrands(Guid spareId)
      {
         SpareToReturn? spare = await _mediator.Send(new GetSpareWithBrandsQuery()
         {
            SpareId = spareId
         });

         if (spare == null)
         {
            return NotFound();
         }

         return Ok(spare);
      }

      [HttpGet]
      public async Task<ActionResult<IReadOnlyList<SpareToReturn>>> GetSparesWithBrands(GetSparesWithBrandsQuery filter)
      {
         var spares = await _mediator.Send(filter);

         return Ok(spares);
      }




   }
}
