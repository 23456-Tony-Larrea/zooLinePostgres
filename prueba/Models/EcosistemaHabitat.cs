using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class EcosistemaHabitat {
      [Key]
        public int Id { get; set; }
        [ForeignKey(name: "Ecosistema")]
        public int EcosistemaId { get; set; }
        public Ecosistema Ecosistema { get; set; }
        [ForeignKey(name: "Habitat")]
        public int HabitatId { get; set; }
        public Habitat Habitat { get; set; }
    }
}
