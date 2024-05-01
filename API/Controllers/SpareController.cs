using API.Wrapper;
using Core.Contracts.Service.SpareService;
using Core.Contracts.Service.SpareBrand;
using Core.Dtos.SpareDto;
using Microsoft.AspNetCore.Mvc;
using Core.Domain.Entities;

namespace API.Controllers
{
    [Route("api/spares")]
    [ApiController]
    public class SpareController : Controller
    {
        private readonly ISpareAddService _spareAddService;
        private readonly ISpareGetService _spareGetService;
        private readonly ISpareBrandAddService _spareBrandAddService;
        private readonly ISpareDeleteService _spareDeleteService;

        public SpareController(ISpareAddService spareAddService, ISpareGetService spareGetService, ISpareBrandAddService spareBrandAddService, ISpareDeleteService spareDeleteService)
        {
            _spareAddService = spareAddService;
            _spareGetService = spareGetService;
            _spareBrandAddService = spareBrandAddService;
            _spareDeleteService = spareDeleteService;
        }

        [HttpPost]
        public async Task<ActionResult<SpareToReturn>> AddSpare(SpareToAdd spareToAdd)
        {
            try
            {
                var spareToReturn = await _spareAddService.AddSpare(spareToAdd);

                return CreatedAtRoute("GetSpare",
                    new
                    {
                        spareId = spareToReturn.SpareId
                    }, spareToReturn);
            }
            catch (InvalidOperationException ex)
            {
                // Return a BadRequest or Conflict response with a custom error message
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{spareId}",Name ="GetSpare" )]
        public async Task<ActionResult<SpareToReturn>> GetSpare(Guid spareId)
        {
            SpareToReturn? spare = await _spareGetService.GetSpareById(spareId);

            if (spare == null)
            {
                return NotFound();
            }

            return Ok(spare);
        }

        [HttpGet("SparesWithBrands")]
        public async Task<ActionResult<IReadOnlyList<SpareWithBrandToReturn>>> GetSparesWithBrands()
        {
            var spares = await _spareGetService.GetSparesWithBrands();

            return Ok(spares);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpareToReturn>>> GetAllSpare()
        {
            IReadOnlyList<SpareToReturn> spares =  await _spareGetService.GetSpares();

            return Ok(spares);
        }

        [HttpDelete("{spareId}")]
        public async Task<ActionResult> DeleteSpare(Guid spareId)
        {   
            Spare? spare =  await _spareDeleteService.DeleteSpare(spareId);

            if(spare == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpPost("AddBrand")]
        public async Task<ActionResult<bool>> AddBrandToSpare(SpareBrandAndPriceToAdd data )
        {
            try
            {
                bool status = await _spareBrandAddService.AddBrandToSpare(data.SpareBrandToAdd, data.PriceToAdd);
                return Ok(status);

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
