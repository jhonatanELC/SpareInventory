using Core.Contracts.Service.Vehicle;
using Core.Dtos.VehicleDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleAddService _vehicleAddService;
        private readonly IVehicleGetService _vehicleGetService;

        public VehicleController(IVehicleAddService vehicleAddService, IVehicleGetService vehicleGetService )
        {
            _vehicleAddService = vehicleAddService;
            _vehicleGetService = vehicleGetService;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleToReturn>> AddVehicle(VehicleToAdd vehicleToAdd)
        {
            var vehicleToReturn = await _vehicleAddService.AddVehicle(vehicleToAdd);

            return Ok(vehicleToReturn);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<VehicleToReturn>>> GetVehicles()
        {
            var vehicles = await _vehicleGetService.GetVehicles();

            return Ok(vehicles);
        }
    }
}
