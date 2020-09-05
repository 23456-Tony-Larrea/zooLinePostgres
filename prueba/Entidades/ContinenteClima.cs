using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class ContinenteClima {
       [Key]
        public int ContinenteClimaId { get; set; }
        [ForeignKey(name: "Continente")]
        public int ContinenteId { get; set; }
        public Continente Continente { get; set; }
        [ForeignKey(name: "Clima")]
        public int ClimaId { get; set; }
        public Clima Clima { get; set; }
    }
}
