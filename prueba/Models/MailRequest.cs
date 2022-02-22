using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLine.Models
{
    public class MailRequest
    {
        public string Email { get; set; }
        public string Tema { get; set; }
        public string Cuerpo { get; set; }
    }
}
