using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        public string CodigoHabitat { get; set; }
        public string NombreHabitat{ get; set; }
        public List<HabitatClima> HabitatClima { get; set; }

    }
}
