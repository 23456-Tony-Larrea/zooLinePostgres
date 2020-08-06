using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Usuario
    {
        [Key]
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
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        [Display(Name="Su fotografia")]
        public byte[] FotografiaPerfil { get; set; }
        
        [NotMapped]
        public string FotografiaBase64 { get; set; }
        public List <UsuarioRol>UsuarioRoles { get; set; }

    }

}
