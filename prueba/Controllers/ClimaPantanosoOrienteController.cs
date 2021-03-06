﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using ZooLine.Models;

namespace ZooLine.Views.ClimaPantanosoOriente
{
    public class ClimaPantanosoOrienteController : Controller
    {
        private readonly ApplicationDbContext _dbAplicacion;
        public ClimaPantanosoOrienteController(ApplicationDbContext context)
        {
            _dbAplicacion = context;
        }
        [Route("[controller]")]
        [Route("[controller]/Index")]
        public async Task<IActionResult> Index()
        {

            var animales = await _dbAplicacion.Animales.Where(x => x.EspecieId ==69|| x.EspecieId == 68|| x.EspecieId == 70|| x.EspecieId == 67).OrderByDescending(x => x.AnimalId).Select(x => new CardModel
            {
                Descripcion = x.descripcion,
                SubDescripcion = x.año_muerte.ToString(),
                ImageUrl = x.NombreImagen,
                SubTitulo = x.NombreCientifico,
                Titulo = x.Nombre

            }).ToListAsync();
            return View(animales);

        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (!int.TryParse(id, out var EspecieId))
                return View(new List<CardModel>());

            var animales = await _dbAplicacion.Animales.Where(x => x.EspecieId == EspecieId).OrderByDescending(x => x.AnimalId).Select(x => new CardModel
            {
                Descripcion = x.descripcion,
                SubDescripcion = x.año_muerte.ToString(),
                ImageUrl = x.NombreImagen,
                SubTitulo = x.NombreCientifico,
                Titulo = x.Nombre

            }).ToListAsync();
            return View(animales);

        }


    }
}
