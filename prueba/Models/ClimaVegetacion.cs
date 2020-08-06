using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class ClimaVegetacion {
       [Key]
        public int Id { get; set; }
        [ForeignKey(name: "Clima")]
        public int climaId { get; set; }
        public Clima Clima{ get; set; }
        [ForeignKey(name: "Vegetacion")]
        public int VegetacionId { get; set; }
        public Vegetacion Vegetacion { get; set; }
        
    }
}
