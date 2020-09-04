using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Usuario tour")]
        public string UsuarioId { get; set; }
        [Display(Name = "Hora de entrada")]
        public DateTime HoraEntrada { get; set; }
        [Display(Name = "Hora de salida")]
        public DateTime HoraSalida { get; set; }
        [Display(Name = "Maximo de Usuarios")]
        public int MaxUsuarios { get; set; }
        public List<TourContinente> TourContinentes { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<TourUsuario> TourUsuarios { get; set; }

    }
}
