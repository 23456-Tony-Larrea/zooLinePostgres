using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace ZooLine.Controllers
{

    public class CarruselController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
