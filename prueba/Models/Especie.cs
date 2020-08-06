using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Especie {
        [Key]
        public int EspecieId { get; set; }
        public string NombreEspecie { get; set; }
        public List<Animales> Animales { get; set; }
    }
}
