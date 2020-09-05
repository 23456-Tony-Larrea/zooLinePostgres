using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
