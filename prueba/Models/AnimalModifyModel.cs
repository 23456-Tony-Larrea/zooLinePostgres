using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZooLine.Models
{
    public class AnimalModifyModel
    {
        public int AnimalId { get; set; }
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public int año_nacimiento { get; set; }
        public int año_muerte { get; set; }
        public decimal estatura { get; set; }
        public decimal ancho { get; set; }
        public string Titulo { get; set; }
        public string NombreImagen { get; set; }
        public IFormFile ImagenArchivo { get; set; }
        public string descripcion { get; set; }      
        public int EspecieId { get; set; }
        public  SelectList Especies { get; set; }
    }   
}
