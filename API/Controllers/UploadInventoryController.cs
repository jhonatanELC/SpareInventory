using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Inventory")]
    [ApiController]
    public class UploadInventoryController : Controller
    {
        public async Task<IActionResult> UploadCsvFile(IFormFile file)
        {
            return Ok();
        }
    }
}
