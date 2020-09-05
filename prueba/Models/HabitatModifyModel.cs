using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZooLine.Models
{
    public class HabitatModifyModel
    {
   
        public int EspecieId { get; set; }   
        public string NombreEspecie { get; set; }
        public int HabitatId { get; set; }
        public SelectList Habitas { get; set; }
    }
}
