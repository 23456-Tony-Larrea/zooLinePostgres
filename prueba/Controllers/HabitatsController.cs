﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using prueba.Models;
using ZooLine.Models;

namespace ZooLine.Controllers

{
    [Authorize(Roles = "guia")]
    public class HabitatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: Habitats
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Habitat.ToListAsync());
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
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_habitat" : "";
            var habitat = from s in _context.Habitat
                         select s;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                habitat = habitat.Where(s => s.NombreHabitat.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_clima":
                    habitat = habitat.OrderByDescending(s => s.NombreHabitat);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Habitat>.CreateAsync(habitat.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Habitats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat
                .FirstOrDefaultAsync(m => m.HabitatId == id);
            if (habitat == null)
            {
                return NotFound();
            }

            return View(habitat);
        }

        // GET: Habitats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitatId,CodigoHabitat,NombreHabitat")] Habitat habitat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitat);
        }

        // GET: Habitats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat.FindAsync(id);
            if (habitat == null)
            {
                return NotFound();
            }
            return View(habitat);
        }

        // POST: Habitats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitatId,CodigoHabitat,NombreHabitat")] Habitat habitat)
        {
            if (id != habitat.HabitatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitatExists(habitat.HabitatId))
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
            return View(habitat);
        }

        // GET: Habitats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat
                .FirstOrDefaultAsync(m => m.HabitatId == id);
            if (habitat == null)
            {
                return NotFound();
            }

            return View(habitat);
        }

        // POST: Habitats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitat = await _context.Habitat.FindAsync(id);
            _context.Habitat.Remove(habitat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitatExists(int id)
        {
            return _context.Habitat.Any(e => e.HabitatId == id);
        }

    }
}