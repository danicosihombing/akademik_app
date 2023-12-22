using Microsoft.AspNetCore.Mvc;

namespace Test7.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

       
    }
}