using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Clima
    {
       [Key]
        public int ClimaId { get; set; }
        public string NombreClima { get; set; }
        public List<HabitatClima> HabitatClima { get; set; }


    }
}
