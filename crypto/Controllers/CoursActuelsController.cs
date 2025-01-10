using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    public class CoursActuelsController : Controller
    {
        public IActionResult Index()
        {
            return View("CoursActuels");
        }
    }
}