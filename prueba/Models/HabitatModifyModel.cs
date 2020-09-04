using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

 namespace ZooLine.Models
{
    public class HabitatModifyModel
    {
   
        public int EspecieId { get; set; }   
        public string NombreEspecie { get; set; }
        public int HabitatId { get; set; }
        public SelectList Habitas { get; set; }
    }
}
