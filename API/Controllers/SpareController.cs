using Core.Contracts.Service.Spare;
using Core.Dtos.SpareDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/spares")]
    [ApiController]
    public class SpareController : Controller
    {
        private readonly ISpareAddService _spareAddService;
        private readonly ISpareGetService _spareGetService;

        public SpareController(ISpareAddService spareAddService, ISpareGetService spareGetService)
        {
            _spareAddService = spareAddService;
            _spareGetService = spareGetService;
        }

        [HttpPost]
        public async Task<ActionResult<SpareToReturn>> AddSpare(SpareToAdd spareToAdd)
        {
            var spareToReturn = await _spareAddService.AddSpare(spareToAdd);

            return Ok(spareToReturn);
        }

        [HttpGet("{spareId}")]
        public async Task<ActionResult<SpareToReturn>> GetSpare(Guid spareId)
        {
            SpareToReturn? spare = await _spareGetService.GetSpareById(spareId);

            if (spare == null)
            {
                return NotFound();
            }

            return Ok(spare);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpareToReturn>>> GetAllSpare()
        {
            IReadOnlyList<SpareToReturn> spares =  await _spareGetService.GetSpares();

            return Ok(spares);
        }
    }
}
