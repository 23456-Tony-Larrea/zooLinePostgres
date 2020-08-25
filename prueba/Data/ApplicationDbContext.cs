using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<prueba.Models.Animales> Animales { get; set; }
        public DbSet<prueba.Models.Tour> Tour { get; set; }
        public DbSet<prueba.Models.Clima> Clima { get; set; }
        public DbSet<prueba.Models.Especie> Especie { get; set; }
        public DbSet<prueba.Models.Habitat> Habitat { get; set; }
        public DbSet<prueba.Models.Continente> Continente { get; set; }
        public DbSet<prueba.Models.Usuario> Usuario { get; set; }
    
    }
}
