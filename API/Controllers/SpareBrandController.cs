using API.Wrapper;
using Core.Contracts.Service.PriceService;
using Core.Contracts.Service.SpareBrandService;
using Core.Domain.Entities;
using Core.Dtos.PriceDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/sparebrand")]
    [ApiController]
    public class SpareBrandController : Controller
    {
        private readonly IPriceAddService _priceAddService;
        private readonly ISpareBrandAddService _spareBrandAddService;
        private readonly IPriceUpdateService _priceUpdateService;

        public SpareBrandController(IPriceAddService priceAddService, ISpareBrandAddService spareBrandAddService, IPriceUpdateService priceUpdateService)
        {
            _priceAddService = priceAddService;
            _spareBrandAddService = spareBrandAddService;
            _priceUpdateService = priceUpdateService;
        }

        [HttpPost("price/{spareBrandId}")]
        public async Task<ActionResult> AddPrice(PriceToAdd priceToAdd, Guid spareBrandId)
        {
            bool result = await _priceAddService.AddPrice(priceToAdd, spareBrandId );

            if (!result) { return BadRequest(); }

            return Ok(result);
        }

        [HttpPut("price/{spareBrandId}")]
        public async Task<ActionResult> EditPrice([FromBody] PriceToAdd priceToUpdate, Guid spareBrandId)
        {   
            Price? price = await _priceUpdateService.UpdatePrice(priceToUpdate, spareBrandId);

            if (price == null) return BadRequest();

            return Ok();
        }

        [HttpPost()]
        public async Task<ActionResult<bool>> AddBrandWithPriceToSpare(SpareBrandAndPriceToAdd data)
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
