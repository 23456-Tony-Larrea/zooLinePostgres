using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Continente
    {
        [Key]
        public int ContinenteId { get; set; }
        public string NombreContinente { get; set; }
       public List<ContinenteEcosistema> ContinenteEcosisitema { get; set; }

    }
}
