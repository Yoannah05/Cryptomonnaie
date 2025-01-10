using crypto.Models;
using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    public class PorteFeuilleController : Controller
    {
        public IActionResult Index()
        {
            return View("PorteFeuille"); 
        }
    }
}
