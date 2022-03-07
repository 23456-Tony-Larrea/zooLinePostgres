using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Views.Message
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
