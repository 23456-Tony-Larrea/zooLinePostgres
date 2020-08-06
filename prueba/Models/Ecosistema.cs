using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Ecosistema
    {
        [Key]
        public int EcosistemaId { get; set; }
        public string CodigoEcosistema { get; set; }
        public string NombreEcositem { get; set; }
       public List<EcosistemaHabitat> EcosistemaHabitat { get; set; }
    }
}
