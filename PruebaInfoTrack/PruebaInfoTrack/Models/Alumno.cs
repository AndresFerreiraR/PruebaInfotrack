using System;
using System.Collections.Generic;

namespace PruebaInfoTrack.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Notas = new HashSet<Notas>();
        }

        public int IdAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Notas> Notas { get; set; }
    }
}
