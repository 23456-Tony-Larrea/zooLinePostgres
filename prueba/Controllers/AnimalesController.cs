using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;

namespace ZooLine.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnimalesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Animales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Animales.Include(a => a.Especie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Animales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animales
                .Include(a => a.Especie)
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
            ViewData["EspecieId"] = new SelectList(_context.Especie, "EspecieId", "EspecieId");
            return View();
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,Nombre,NombreCientifico,año_nacimiento,año_muerte,estatura,ancho,Titulo,ImagenArchivo,descripcion,EspecieId")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(animales.ImagenArchivo.FileName);
                string extension = Path.GetExtension(animales.ImagenArchivo.FileName);
                animales.NombreImagen = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await animales.ImagenArchivo.CopyToAsync(fileStream);
                }

                _context.Add(animales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecieId"] = new SelectList(_context.Especie, "EspecieId", "EspecieId", animales.EspecieId);
            return View(animales);
        }

        // GET: Animales/Edit/5
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
            ViewData["EspecieId"] = new SelectList(_context.Especie, "EspecieId", "EspecieId", animales.EspecieId);
            return View(animales);
        }

        // POST: Animales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Nombre,NombreCientifico,año_nacimiento,año_muerte,estatura,ancho,Titulo,NombreImagen,descripcion,EspecieId")] Animales animales)
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
            ViewData["EspecieId"] = new SelectList(_context.Especie, "EspecieId", "EspecieId", animales.EspecieId);
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
                .Include(a => a.Especie)
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
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "img", animales.NombreImagen);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

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
