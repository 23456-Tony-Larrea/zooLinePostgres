using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int MaxUsuarios { get; set; }
        public List<TourContinente> TourContinentes { get; set; }

    }
}
