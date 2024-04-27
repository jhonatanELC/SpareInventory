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

        public VehicleController(IVehicleAddService vehicleAddService)
        {
            _vehicleAddService = vehicleAddService;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleToReturn>> AddBrand(VehicleToAdd vehicleToAdd)
        {
            var vehicleToReturn = await _vehicleAddService.AddVehicle(vehicleToAdd);

            return Ok(vehicleToReturn);
        }
    }
}
