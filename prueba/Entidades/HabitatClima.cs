using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class HabitatClima {
      [Key]
        public int Id { get; set; }
        [ForeignKey(name: "Habitat")]
        public int HabitatId { get; set; }
        public Habitat Habitat{ get; set; }
        [ForeignKey(name: "Clima")]
        public int climaId { get; set; }
        public Clima Clima{ get; set; }
    }
}
