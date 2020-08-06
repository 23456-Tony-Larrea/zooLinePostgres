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
    [Authorize(Roles = "Guia")]

    public class EcosistemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EcosistemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ecosistemas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ecosistema.ToListAsync());
        }

        // GET: Ecosistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistema
                .FirstOrDefaultAsync(m => m.EcosistemaId == id);
            if (ecosistema == null)
            {
                return NotFound();
            }

            return View(ecosistema);
        }

        // GET: Ecosistemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ecosistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EcosistemaId,CodigoEcosistema,NombreEcositem")] Ecosistema ecosistema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecosistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ecosistema);
        }

        // GET: Ecosistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistema.FindAsync(id);
            if (ecosistema == null)
            {
                return NotFound();
            }
            return View(ecosistema);
        }

        // POST: Ecosistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EcosistemaId,CodigoEcosistema,NombreEcositem")] Ecosistema ecosistema)
        {
            if (id != ecosistema.EcosistemaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecosistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcosistemaExists(ecosistema.EcosistemaId))
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
            return View(ecosistema);
        }

        // GET: Ecosistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecosistema = await _context.Ecosistema
                .FirstOrDefaultAsync(m => m.EcosistemaId == id);
            if (ecosistema == null)
            {
                return NotFound();
            }

            return View(ecosistema);
        }

        // POST: Ecosistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ecosistema = await _context.Ecosistema.FindAsync(id);
            _context.Ecosistema.Remove(ecosistema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcosistemaExists(int id)
        {
            return _context.Ecosistema.Any(e => e.EcosistemaId == id);
        }
    }
}
