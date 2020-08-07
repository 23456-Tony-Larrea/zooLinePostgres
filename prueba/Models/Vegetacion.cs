using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Vegetacion {
        [Key]
        public int VegetacionId { get; set; }
        public string NombreVegetacion { get; set; }
        public List<ClimaVegetacion> ClimaVegetacion { get; set; }
    }
}
