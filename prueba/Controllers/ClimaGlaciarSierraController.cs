using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Views.ClimaGlaciarSierra
{
    public class ClimaGlaciarSierraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
