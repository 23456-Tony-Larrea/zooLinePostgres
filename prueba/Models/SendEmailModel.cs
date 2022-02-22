using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLine.Models
{
    public class SendEmailModel
    {
        [Required(ErrorMessage ="El Email es requerido")]
        [EmailAddress(ErrorMessage = "El Mail no es valido")]
        public string Email{ get; set; }
        [Required(ErrorMessage = "El mensage es requerido")]
        public string Content { get; set; }
        public bool? Succes { get; set; }
    }
}
