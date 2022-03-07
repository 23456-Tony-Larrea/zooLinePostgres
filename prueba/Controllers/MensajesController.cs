using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Controllers
{
    public class MensajesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
