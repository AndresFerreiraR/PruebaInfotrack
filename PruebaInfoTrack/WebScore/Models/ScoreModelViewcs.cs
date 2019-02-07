using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScore.Models
{
    public class ScoreModelViewcs
    {
        public int IdNota { get; set; }
        public int? IdEstudiante { get; set; }
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public decimal? Nota { get; set; }
    }
}
