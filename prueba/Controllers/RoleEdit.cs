using Microsoft.AspNetCore.Identity;
using prueba.Models;
using System.Collections.Generic;

namespace Identity.Controllers
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public List<Usuario> Members { get; set; }
        public List<Usuario> NonMembers { get; set; }
    }
}