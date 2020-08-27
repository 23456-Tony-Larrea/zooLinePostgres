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

namespace ZooLine.Controllers
{
    [Authorize(Roles = "guia")]
    public class ContinentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContinentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Continentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Continente.ToListAsync());
        }

        // GET: Continentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continente = await _context.Continente
                .FirstOrDefaultAsync(m => m.ContinenteId == id);
            if (continente == null)
            {
                return NotFound();
            }

            return View(continente);
        }

        // GET: Continentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Continentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContinenteId,NombreContinente")] Continente continente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(continente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(continente);
        }

        // GET: Continentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continente = await _context.Continente.FindAsync(id);
            if (continente == null)
            {
                return NotFound();
            }
            return View(continente);
        }

        // POST: Continentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContinenteId,NombreContinente")] Continente continente)
        {
            if (id != continente.ContinenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(continente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContinenteExists(continente.ContinenteId))
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
            return View(continente);
        }

        // GET: Continentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continente = await _context.Continente
                .FirstOrDefaultAsync(m => m.ContinenteId == id);
            if (continente == null)
            {
                return NotFound();
            }

            return View(continente);
        }

        // POST: Continentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var continente = await _context.Continente.FindAsync(id);
            _context.Continente.Remove(continente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContinenteExists(int id)
        {
            return _context.Continente.Any(e => e.ContinenteId == id);
        }
    }
}
