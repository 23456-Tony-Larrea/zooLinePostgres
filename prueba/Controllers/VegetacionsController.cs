﻿using System;
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
    //[Authorize(Roles = "Guia")]

    public class VegetacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VegetacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vegetacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vegetacion.ToListAsync());
        }

        // GET: Vegetacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetacion = await _context.Vegetacion
                .FirstOrDefaultAsync(m => m.VegetacionId == id);
            if (vegetacion == null)
            {
                return NotFound();
            }

            return View(vegetacion);
        }

        // GET: Vegetacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegetacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VegetacionId,NombreVegetacion")] Vegetacion vegetacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegetacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegetacion);
        }

        // GET: Vegetacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetacion = await _context.Vegetacion.FindAsync(id);
            if (vegetacion == null)
            {
                return NotFound();
            }
            return View(vegetacion);
        }

        // POST: Vegetacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VegetacionId,NombreVegetacion")] Vegetacion vegetacion)
        {
            if (id != vegetacion.VegetacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegetacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegetacionExists(vegetacion.VegetacionId))
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
            return View(vegetacion);
        }

        // GET: Vegetacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetacion = await _context.Vegetacion
                .FirstOrDefaultAsync(m => m.VegetacionId == id);
            if (vegetacion == null)
            {
                return NotFound();
            }

            return View(vegetacion);
        }

        // POST: Vegetacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vegetacion = await _context.Vegetacion.FindAsync(id);
            _context.Vegetacion.Remove(vegetacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VegetacionExists(int id)
        {
            return _context.Vegetacion.Any(e => e.VegetacionId == id);
        }
    }
}
