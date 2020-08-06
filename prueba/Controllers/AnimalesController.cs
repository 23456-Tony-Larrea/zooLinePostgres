using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;
using ZooLine.ViewModels;

namespace ZooLine.Controllers
{
    //[Authorize(Roles = "Guia")]
    public class AnimalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animales
        public async Task<IActionResult> Index()
        {
            var animal = await _context.Animales.ToListAsync();
            animal.ForEach(p => p.FotografiaBase64 = $"data:image/png;base64,{Convert.ToBase64String(p.fotoAnimal)}");

            return View(animal);
        }

        // GET: Animales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animales
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animales == null)
            {
                return NotFound();
            }

            return View(animales);
        }

        // GET: Animales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalesViewsMode modelo)
        {
            if (ModelState.IsValid)
            {
                Animales animales = new Animales
                {
                    Nombre = modelo.Nombre,
                    ancho = modelo.ancho,
                    año_muerte = modelo.año_muerte,
                    año_nacimiento = modelo.año_nacimiento,
                    estatura = modelo.estatura,
                    NombreCientifico = modelo.NombreCientifico,
                    fotoAnimal = await ArchivoSubidoAsync(modelo.fotoAnimal)

                };

                _context.Add(animales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        private async Task<byte[]> ArchivoSubidoAsync(IFormFile fotoAnimal)
        {
            if (fotoAnimal == null) return null;
               var memoryStream = new MemoryStream();
                await fotoAnimal.CopyToAsync(memoryStream);
                var limiteMax = 2097152;
               if (memoryStream.Length < limiteMax)

                  return memoryStream.ToArray();
                   return null;        
        }


           //// GET: Animales/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animales.FindAsync(id);
            if (animales == null)
            {
                return NotFound();
            }
            return View(animales);
        }

        // POST: Animales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Nombre,NombreCientifico,año_nacimiento,año_muerte,estatura,ancho,fotoAnimal")] Animales animales)
        {
            if (id != animales.AnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalesExists(animales.AnimalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animales);
        }

        // GET: Animales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animales
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animales == null)
            {
                return NotFound();
            }

            return View(animales);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animales = await _context.Animales.FindAsync(id);
            _context.Animales.Remove(animales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalesExists(int id)
        {
            return _context.Animales.Any(e => e.AnimalId == id);
        }
    }
}
