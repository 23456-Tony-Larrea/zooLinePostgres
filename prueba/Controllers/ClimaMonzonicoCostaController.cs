using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Views.ClimaMonzonicoCosta
{
    public class ClimaMonzonicoCostaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
