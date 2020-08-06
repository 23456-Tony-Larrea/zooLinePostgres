using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class VegetacionAnimal {
        [Key]
        public int Id { get; set; }
        [ForeignKey(name: "Vegetacion")]
        public int VegetacionId { get; set; }
        public Vegetacion Vegetacion { get; set; }
        [ForeignKey(name: "Animal")]
        public int AnimalId { get; set; }
        public Animales Animales { get; set; }
    }
}
