﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZooLine.Views.ClimaOriente
{
    public class ClimaOrienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
