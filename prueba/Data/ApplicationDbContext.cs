using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // fluent api Entity frammework 
           
            builder.Entity<Usuario>().HasMany(x => x.Tours).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
            builder.Entity<Usuario>().HasMany(x => x.TourUsuarios).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
            builder.Entity<Tour>().HasMany(x => x.TourUsuarios).WithOne(x => x.Tour).HasForeignKey(x => x.TourId);
            builder.Entity<TourUsuario>().HasKey(x => new { x.TourId, x.UsuarioId });
            base.OnModelCreating(builder);
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
