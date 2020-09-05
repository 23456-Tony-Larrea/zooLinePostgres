using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Controllers
{
    public class GalapagosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
