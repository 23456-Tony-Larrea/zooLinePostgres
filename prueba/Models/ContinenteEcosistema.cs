using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class ContinenteEcosistema {
       [Key]
        public int ContinenteEcosistemaId { get; set; }
        [ForeignKey(name: "Continente")]
        public int ContinenteId { get; set; }
        public Continente Continente { get; set; }
        [ForeignKey(name: "Ecosistema")]
        public int EcosistemaId { get; set; }
        public Ecosistema Ecosistema { get; set; }
    }
}
