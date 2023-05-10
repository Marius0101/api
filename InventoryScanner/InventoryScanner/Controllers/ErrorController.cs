using Microsoft.AspNetCore.Mvc;

namespace InventoryScanner.Controllers
{
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
