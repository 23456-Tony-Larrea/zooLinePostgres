using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Tour
    {
        public Tour()
        {
            TourUsuarios = new HashSet<TourUsuario>();
        }
        [Key]
        public int TourId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int MaxUsuarios { get; set; }
        public List<TourContinente> TourContinentes { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<TourUsuario> TourUsuarios { get; set; }

    }
}
