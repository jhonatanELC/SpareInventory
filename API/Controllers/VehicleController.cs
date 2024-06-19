using Core.Features.Vehicles.Commands.CreateVehicle;
using Core.Features.Vehicles.Commands.DeleteVehicle;
using Core.Features.Vehicles.Queries.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [Route("api/vehicles")]
   [ApiController]
   public class VehicleController : Controller
   {
      private readonly IMediator _mediator;

      public VehicleController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost]
      public async Task<ActionResult<Guid>> AddVehicle(CreateVehicleCommand vehicle)
      {
         Guid? vehicleId = await _mediator.Send(vehicle);

         if (vehicleId == null)
         {
            return BadRequest("Already exists a vehicle with the same brand and model");
         }
         return Ok(vehicleId);
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetVehicles()
      {
         var vehicles = await _mediator.Send(new GetVehiclesQuery());

         return Ok(vehicles);
      }

      [HttpDelete("{vehicleId}")]
      public async Task<IActionResult> DeleteVehicle(Guid vehicleId)
      {
         bool response = await _mediator.Send(new DeleteVehicleCommand() { VehicleId = vehicleId });
         if (!response) return NotFound();

         return NoContent();
      }
   }
}