using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class UsuarioRol 
    {
        [Key]
        public int UsuarioRolId { get; set; }
        [ForeignKey(name: "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey(name:"Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
