using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba.Models
{
    public class Animales {
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = @"El ""nombre"" es obligatorio:")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = @"El ""nombre cientifico"" es obligatorio:")]
        [Display(Name = "Nombre Cientifico")]
        public string NombreCientifico { get; set; }
        [Required(ErrorMessage = @"El ""año de nacimiento"" es obligatorio:")]
        [Display(Name = "Año de nacimiento ")]
        public int año_nacimiento { get; set; }
        [Required(ErrorMessage = @"La ""año de muerte"" es obligatoria:")]
        [Display(Name = "Año de muerte")]
        public int año_muerte { get; set; }

        public decimal estatura { get; set; }
        [Required(ErrorMessage = @"La ""estatura"" es obligatoria:")]
        [Display(Name = "Estatura")]

        public decimal ancho { get; set; }
        [Required(ErrorMessage = @"El ""Ancho"" es obligatoria:")]
        [Display(Name = "Ancho")]
        public byte[] fotoAnimal { get; set; }
        [Display(Name = "Foto del animal")]
        [NotMapped]
        public string FotografiaBase64 { get; set; }
        public List<VegetacionAnimal> VegetacionAnimal { get; set; }


        [ForeignKey(name: "Especie")]
        public int EspecieId { get; set; }
        public Especie Especie { get; set; }
    }
}
