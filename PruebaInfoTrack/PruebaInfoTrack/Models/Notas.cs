using System;
using System.Collections.Generic;

namespace PruebaInfoTrack.Models
{
    public partial class Notas
    {
        public int IdNota { get; set; }
        public int? IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public decimal? Nota { get; set; }

        public virtual Alumno IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
    }
}
