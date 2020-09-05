using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLine.Models
{


    //creas un modelo para los datos .
    public class AnimalIndexDataModel
    {

        public string AnimalId { get; set; }

        //esto 

        [DisplayName("subir archivo")]
        public IFormFile ImagenArchivo { get; set; }



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
        public string Titulo { get; set; }
        public string NombreImagen { get; set; }



        [Required(ErrorMessage = @"LA ""Descripcion"" es obligatoria:")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }


        // aqui es un string
        public string Especie{ get; set; }
    }
    //Y un modelo que contiene los datos Y qui puedes agragar mas cosas 
    // como por ejemplo 
    public class AnimalIndexModel
    {
        public string TituloDePagina = "Animales";
        // si desaas usar un layout diferente 
        public string Layout = "~/Views/Shared/_Layout.cshtml";
        //esto deberia ir en el modelo por ejemplo 
        public AnimalIndexModel()
        {
            Data = new HashSet<AnimalIndexDataModel>();
        }
        public ICollection<AnimalIndexDataModel> Data { get; set; }

   




    }
}
