using System;
using System.Collections.Generic;
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
    public class ClimasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClimasController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Climas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Clima.ToListAsync());
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
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_clima" : "";
            var climas = from s in _context.Clima
                           select s;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                climas = climas.Where(s => s.NombreClima.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_clima":
                    climas = climas.OrderByDescending(s => s.NombreClima);
                    break;
             }
            int pageSize = 5;
            return View(await PaginatedList<Clima>.CreateAsync(climas.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        //// GET: Climas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Clima
                .FirstOrDefaultAsync(m => m.ClimaId == id);
            if (clima == null)
            {
                return NotFound();
            }

            return View(clima);
        }

        // GET: Climas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Climas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClimaId,NombreClima")] Clima clima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clima);
        }

        // GET: Climas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Clima.FindAsync(id);
            if (clima == null)
            {
                return NotFound();
            }
            return View(clima);
        }

        // POST: Climas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClimaId,NombreClima")] Clima clima)
        {
            if (id != clima.ClimaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClimaExists(clima.ClimaId))
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
            return View(clima);
        }

        // GET: Climas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Clima
                .FirstOrDefaultAsync(m => m.ClimaId == id);
            if (clima == null)
            {
                return NotFound();
            }

            return View(clima);
        }

        // POST: Climas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clima = await _context.Clima.FindAsync(id);
            _context.Clima.Remove(clima);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClimaExists(int id)
        {
            return _context.Clima.Any(e => e.ClimaId == id);
        }
        //[HttpGet]
        //public async Task<IActionResult> Index(string climasearch, int? i)
        //{
        //    ViewData["GetClimadetails"]= climasearch;
             
        //    var climquery= from x in _context.Clima select x;
        //    if (!String.IsNullOrEmpty(climasearch))
        //    {
        //       climquery= climquery.Where(x=>x.NombreClima.Contains(climasearch));
        //    }
        //    return View(await climquery.AsNoTracking().ToListAsync());
        //}
    }
}
