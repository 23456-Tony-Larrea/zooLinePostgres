using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ZooLine.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Primer nombre")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Segundo nombre")]
        public string SegundoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Cedula Identidad")]
        public string CedulaIdentidad { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public IFormFile FotografiaPerfil { get; set; } 
    }
}
