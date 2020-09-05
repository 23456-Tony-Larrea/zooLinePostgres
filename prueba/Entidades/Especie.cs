using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Especie {
        [Key]
        public int EspecieId { get; set; }
        public string NombreEspecie { get; set; }
     
        [ForeignKey(name: "Habitat")]
        public int HabitatId { get; set; }
        public Habitat Habitat { get; set; }
    }
}
