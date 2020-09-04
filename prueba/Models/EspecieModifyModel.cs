using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLine.Models
{
    public class EspecieModifyModel
    {
        public int AnimalId { get; set; }
        public string Nombre { get; set; }
        public int EspecieId { get; set; }
        public  SelectList Especies { get; set; }
    }   
}
