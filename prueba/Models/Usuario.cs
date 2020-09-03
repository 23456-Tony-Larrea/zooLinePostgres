using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Usuario: IdentityUser
    {
        public Usuario()
        {
            TourUsuarios = new HashSet<TourUsuario>();
            Tours = new HashSet<Tour>();
        }

        public string PrimerNombre { get; set; }
        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Cedula Identidad")]
        public string CedulaIdentidad { get; set; }

        public string Telefono { get; set; }
        public string Titulo { get; set; }
        public string NombreImagen { get; set; }
        [NotMapped]
        [DisplayName("subir archivo")]
        public IFormFile ImagenArchivo { get; set; }

        public ICollection<TourUsuario> TourUsuarios { get; set; }
        public ICollection<Tour> Tours { get; set; }
        

    }

}
