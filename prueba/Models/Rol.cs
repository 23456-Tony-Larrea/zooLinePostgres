using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Rol {
        [Key]
        public int RolId { get; set; }
        public int MyProperty { get; set; }
        public List<UsuarioRol> UsuarioRoles { get; set; }
    }
}
