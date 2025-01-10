using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    public class InscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View("Inscription");
        }
    }
}