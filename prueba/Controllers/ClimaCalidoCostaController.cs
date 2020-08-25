using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba.Data;
using prueba.Models;

namespace ZooLine.Views.Costa
{
    public class ClimaCalidoCostaController : Controller
    {
        private readonly ApplicationDbContext dbAplicacion;
        public ClimaCalidoCostaController(ApplicationDbContext context)
        {
            dbAplicacion = context;
        }
        public IActionResult Index()
        {
            return View();

        }
       /* public List<Animales> GetAnimales()
        {
            List<Animales> ListaAnimal=dbAplicacion.Animales.Where(animal=>animal.)
        }*/
       
    }
}
