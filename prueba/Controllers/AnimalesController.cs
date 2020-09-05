using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;
using ZooLine.Models;

namespace ZooLine.Controllers
{
    [Authorize(Roles = "guia")]
    public class AnimalesController : ControlladorBase
    {
        public AnimalesController(IMapper mapper, ApplicationDbContext context, IWebHostEnvironment hostEnvironment) : base(mapper, context, hostEnvironment)
        {
        }
        // GET: Animales

        public async Task<IActionResult> Index()
        {

            var data = await _context.Animales.Include(x=> x.Especie).Select(x => x).ToListAsync();
            var model = new AnimalIndexModel{  Data = Map<List<AnimalIndexDataModel>>(data) };
            return View(model);
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
            var model = new AnimalModifyModel();
            model.Especies = new SelectList(_context.Especie.Select(x => new { key = x.NombreEspecie, value = x.EspecieId }).Distinct().OrderBy(x => x.key).ToList(),  "value", "key");
       
            return View(model);
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalModifyModel model)
        {
            
            if (ModelState.IsValid)
            {
                var especie = _context.Especie.FirstOrDefault(x => x.EspecieId.Equals(model.EspecieId));
                //automapper 
                //new Animales
                //{
                //    AnimalId = model.AnimalId,
                //    EspecieId = especie.EspecieId,
                //    Especie = especie,
                //    Nombre = model.Nombre,
                //    NombreCientifico = model.NombreCientifico,
                //    NombreImagen = model.NombreImagen,
                //    ancho = model.ancho,
                //    año_muerte = model.año_muerte,
                //    año_nacimiento = model.año_nacimiento,
                //    descripcion = model.descripcion,
                //    estatura = model.estatura,

                //    Titulo = model.Titulo
                //}
                var data = Map<Animales>(model);
                data.Especie = especie;
                _context.Add(data);
                string wwwRootPath = _hostEnvironment.WebRootPath; 
                string fileName = Path.GetFileNameWithoutExtension(model.ImagenArchivo.FileName);
                string extension = Path.GetExtension(model.ImagenArchivo.FileName);
                var ex = new List<string> { ".JPEG", ".JPG", ".PNG" };
                var result = ex.FirstOrDefault(x => x.ToLower().Equals(extension.ToLower()));
                if (result == null)
                    throw new Exception("Image format no accepted");

               data.NombreImagen = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(Path.Combine(wwwRootPath, "img/Animales"), fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImagenArchivo.CopyToAsync(fileStream);
                }

                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         
            return View(model);
        }

        // GET: Animales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _context.Animales.Select(animal => new AnimalModifyModel
            {
                AnimalId = animal.AnimalId,
                ancho = animal.ancho,
                año_muerte = animal.año_muerte,
                año_nacimiento = animal.año_nacimiento,
                descripcion=animal.descripcion,
                estatura=animal.estatura,
                NombreCientifico=animal.NombreCientifico,
                Nombre=animal.Nombre,
                NombreImagen=animal.NombreImagen,
                Titulo=animal.Titulo,
                EspecieId=animal.EspecieId,
      
            }).FirstOrDefaultAsync(x => x.AnimalId.Equals(id));

            var animales = await _context.Animales.FindAsync(id);
            if (animales == null)
            {
                return NotFound();
            }
            model.Especies = new SelectList((await _context.Especie.Select(x => new { key = x.EspecieId, name = x.NombreEspecie }).Distinct().ToListAsync()), "key", "name");
            return View(model);
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
