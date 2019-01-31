using System;
using System.Collections.Generic;

namespace PruebaInfoTrack.Models
{
    public partial class Materia
    {
        public int IdMateria { get; set; }
        public string Nombres { get; set; }
        public string Descripcion { get; set; }
        public string Docente { get; set; }
        public string Codigo { get; set; }

        public virtual Notas Notas { get; set; }
    }
}
