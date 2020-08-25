using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;

namespace ZooLine.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspeciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Especie.Include(e => e.Habitat);
            return View(await applicationDbContext.ToListAsync());
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
        public IActionResult Create()
        {
            ViewData["HabitatId"] = new SelectList(_context.Habitat, "HabitatId", "HabitatId");
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecieId,NombreEspecie,HabitatId")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitatId"] = new SelectList(_context.Habitat, "HabitatId", "HabitatId", especie.HabitatId);
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            ViewData["HabitatId"] = new SelectList(_context.Habitat, "HabitatId", "HabitatId", especie.HabitatId);
            return View(especie);
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
