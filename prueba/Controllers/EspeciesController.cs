using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;
using ZooLine.Models;

namespace ZooLine.Controllers
{
    [Authorize(Roles = "guia")]
    public class EspeciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspeciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especies

        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Especie.Include(e => e.Habitat);
        //    return View(await applicationDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(
  string sortOrder,
  string currentFilter,
  string searchString,
  int? pageNumber)

        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_especie" : "";
            var especies = from s in _context.Especie
                         select s;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                especies = especies.Where(s => s.NombreEspecie.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_clima":
                    especies = especies.OrderByDescending(s => s.NombreEspecie);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Especie>.CreateAsync(especies.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.Habitat)
                .FirstOrDefaultAsync(m => m.EspecieId == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: Especies/Create
        public async Task<IActionResult> Create()
        {
            var model = new HabitatModifyModel();
            model.Habitas = new SelectList((await _context.Habitat.Select(x => new { key = x.HabitatId, name = x.NombreHabitat }).Distinct().ToListAsync()),"key", "name");
        
           
            return View(model);
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HabitatModifyModel model)
        {
            if (ModelState.IsValid)
            {
               var habitat =  _context.Habitat.FirstOrDefault(x => x.HabitatId.Equals(model.HabitatId));
                if(habitat == null)
                {
                    ModelState.AddModelError("HabitatId", "HabitaId no fue encontrado");
                    return View();
                }
                _context.Add(new Especie { 
                        EspecieId = model.EspecieId,
                       HabitatId = habitat.HabitatId,
                       Habitat = habitat, 
                       NombreEspecie = model.NombreEspecie
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         
            return View();
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Especie.Select(especie => new HabitatModifyModel
            {
                HabitatId = especie.HabitatId,
                NombreEspecie = especie.NombreEspecie,
                EspecieId = especie.EspecieId,

            }).FirstOrDefaultAsync(x => x.EspecieId.Equals(id));

            if (model == null)
            {
                return NotFound();
            }
            model.Habitas = new SelectList((await _context.Habitat.Select(x => new { key = x.HabitatId, name = x.NombreHabitat }).Distinct().ToListAsync()), "key", "name");
            return View(model);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecieId,NombreEspecie,HabitatId")] Especie especie)
        {
            if (id != especie.EspecieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.EspecieId))
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
            ViewData["HabitatId"] = new SelectList(_context.Habitat, "HabitatId", "HabitatId", especie.HabitatId);
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.Habitat)
                .FirstOrDefaultAsync(m => m.EspecieId == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.Especie.FindAsync(id);
            _context.Especie.Remove(especie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.EspecieId == id);
        }
        
    }
}
