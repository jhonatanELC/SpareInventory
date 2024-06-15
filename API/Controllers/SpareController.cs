using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Features.Spares.Commands.DeleteSpare;

namespace API.Controllers
{
   [Route("api/spares")]
   [ApiController]
   public class SpareController : Controller
   {
      private readonly IMediator _mediator;

      public SpareController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpDelete("{spareId}")]
      public async Task<ActionResult> DeleteSpare(Guid spareId)
      {
         var deleteSpareCommand = new DeleteSpareCommand() { SpareId = spareId };
         var response = await _mediator.Send(deleteSpareCommand);

         if (response) return NoContent();

         return NotFound();
      }
   }
}
