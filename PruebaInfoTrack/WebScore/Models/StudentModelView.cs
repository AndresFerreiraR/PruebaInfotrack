using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebScore.Models
{
    public class StudentModelView
    {
        public int IdAlumno { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Identificacion { get; set; }

        public string Telefono { get; set; }
                
        public string Correo { get; set; }
    }
}
