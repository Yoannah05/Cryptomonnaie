using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    public class CoursCryptomonnaie : Controller
    {
        public IActionResult Index()
        {
            return View("CoursCryptomonnaie");
        }
    }
}