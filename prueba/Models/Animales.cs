using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Animales {
        [Key]
        public int AnimalId { get; set; }

        public string Nombre { get; set; }

        public string NombreCientifico { get; set; }

        public int año_nacimiento { get; set; }

        public int año_muerte { get; set; }

        public decimal estatura { get; set; }

        public decimal ancho { get; set; }

        public byte[] fotoAnimal { get; set; }
        [NotMapped]
        public string FotografiaBase64 { get; set; }
        public List<VegetacionAnimal> VegetacionAnimal { get; set; }


        [ForeignKey(name: "Especie")]
        public int EspecieId { get; set; }
        public Especie Especie { get; set; }
    }
}
