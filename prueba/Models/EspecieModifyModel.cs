using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZooLine.Models
{
    public class EspecieModifyModel
    {
        public int AnimalId { get; set; }
        public string Nombre { get; set; }
        public int EspecieId { get; set; }
        public  SelectList Especies { get; set; }
    }   
}
