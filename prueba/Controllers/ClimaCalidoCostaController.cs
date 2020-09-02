using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using ZooLine.Models;
namespace ZooLine.Views.Costa
{ 
    public class ClimaCalidoCostaController : Controller
    {
        private readonly ApplicationDbContext _dbAplicacion;
        public ClimaCalidoCostaController(ApplicationDbContext context)
        {
            _dbAplicacion = context;
        }
        [Route("[controller]/{id?}")]
        public async  Task<IActionResult> Index(string id)
        {
            if (!int.TryParse(id, out var EspecieId))
                return View(new List<CardModel>());

           var animales =  await _dbAplicacion.Animales.Where(x=> x.EspecieId == EspecieId).OrderByDescending(x => x.AnimalId).Select(x => new CardModel
            {
                Descripcion = x.descripcion,
                SubDescripcion = x.año_muerte.ToString(),
                ImageUrl = x.NombreImagen,
                SubTitulo = x.NombreCientifico,
                Titulo = x.Nombre

            }).ToListAsync();
            return View(animales);

        }
    
    }
}
     