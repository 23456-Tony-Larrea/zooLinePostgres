using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class TourContinente {
        [Key]
        public  int TourContienteId { get; set; }
       [ForeignKey(name:"Tour")]
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        [ForeignKey(name: "Continente")]
        public int ContinenteId { get; set; }
        public Continente Continente { get; set; }
    }
}
