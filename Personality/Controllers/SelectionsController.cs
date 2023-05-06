using Microsoft.AspNetCore.Mvc;

namespace Personality.Controllers
{
    public class SelectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
