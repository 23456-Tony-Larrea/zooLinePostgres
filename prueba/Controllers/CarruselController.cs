using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Controllers
{
    public class CarruselController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
