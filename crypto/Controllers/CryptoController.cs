using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace crypto.Controllers
{
    [ApiController]
    [Route("Crypto")]
    public class CryptoController : ControllerBase
    {
        [HttpGet("getCoursActuels")]
        public IActionResult GetCoursActuels()
        {
            // Simuler des données statiques
            var coursCryptos = new List<object>
            {
                new { Nom = "Bitcoin", Symbole = "BTC", CoursUSD = 45000.25 },
                new { Nom = "Ethereum", Symbole = "ETH", CoursUSD = 3200.50 },
                new { Nom = "Tether", Symbole = "USDT", CoursUSD = 1.00 },
                new { Nom = "Cardano", Symbole = "ADA", CoursUSD = 0.50 },
                new { Nom = "Solana", Symbole = "SOL", CoursUSD = 22.75 }
            };

            // Retourne le JSON avec les données
            return Ok(coursCryptos);
        }
    }
}
