using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BrandController : Controller
    {   



        public IActionResult Index()
        {
            return View();
        }
    }
}
