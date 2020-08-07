using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Especie {
        [Key]
        public int EspecieId { get; set; }
        public string NombreEspecie { get; set; }
     
        [ForeignKey(name: "Animales")]
        public int AnimalId { get; set; }
        public Animales Animales { get; set; }
    }
}
