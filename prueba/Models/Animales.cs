﻿using System.Collections.Generic;
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
        [Required(ErrorMessage = @"El ""año de muerte"" es obligatoria:")]
        [Display(Name = "Año de muerte")]
        public int año_muerte { get; set; }
        [Required(ErrorMessage = @"La ""estatura"" es obligatoria:")]
        [Display(Name = "Estatura")]
        public decimal estatura { get; set; }
        [Required(ErrorMessage = @"El ""Ancho"" es obligatoria:")]
        [Display(Name = "Ancho")]

        public decimal ancho { get; set; }
        [Required(ErrorMessage = @"LA ""Foto"" es obligatoria:")]
        [Display(Name = "Foto")]
        public byte[] fotoAnimal { get; set; }
    
        public string FotografiaBase64 { get; set; }
        public List<VegetacionAnimal> VegetacionAnimal { get; set; }
     
    }
}
