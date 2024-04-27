using API.Wrapper;
using Core.Contracts.Service.Spare;
using Core.Contracts.Service.SpareBrand;
using Core.Dtos.PriceDto;
using Core.Dtos.SpareBrandDto;
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
        private readonly ISpareBrandAddService _spareBrandAddService;

        public SpareController(ISpareAddService spareAddService, ISpareGetService spareGetService, ISpareBrandAddService spareBrandAddService)
        {
            _spareAddService = spareAddService;
            _spareGetService = spareGetService;
            _spareBrandAddService = spareBrandAddService;
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

        [HttpPost("AddBrand")]
        public async Task<ActionResult<bool>> AddBrandToSpare(SpareBrandAndPriceToAdd data )
        {   
            bool status =  await _spareBrandAddService.AddBrandToSpare(data.SpareBrandToAdd, data.PriceToAdd);

            if (!status) { return BadRequest(); }

            return Ok(status);
        }
    }
}
