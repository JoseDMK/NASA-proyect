using Microsoft.AspNetCore.Mvc;

namespace NASA.Controllers
{
    public class AcercaDeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
