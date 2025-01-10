using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    public class DepotRetraitController : Controller
    {
        public IActionResult Index()
        {
            return View("DepotRetrait");
        }
    }
}