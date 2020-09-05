namespace prueba.Models
{
    public class TourUsuario
    {
     
        public string UsuarioId { get; set; }
       
        public int TourId { get; set; }
        public Usuario Usuario { get; set; }
        public Tour  Tour{get;set;}
    }

}
