using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PruebaInfoTrack.Models;
using PruebaInfoTrack.Services;

namespace PruebaInfoTrack.Controllers
{
    [Route("api/[controller]")]
    public class MateriaController : Controller
    {
        private readonly IMateriaService subjectsService;

        public MateriaController()
        {
            subjectsService = new MateriaService();
        }

        [Route("CrearMateria")]
        public JObject CreateSubject([FromBody] Materia _materia)
        {
            return subjectsService.CreateSubject(_materia);
        }

        [Route("ActualizarMateria")]
        public JObject UpdateSubject([FromBody] Materia _materia)
        {
            return subjectsService.UpdateSubject(_materia);
        }

        [Route("ListarMaterias")]
        public JObject GetAllSubjects()
        {
            return subjectsService.GetAllSubjects();
        }

        [Route("BorrarMateria")]
        public JObject DeleteSubject([FromBody] Materia _materia)
        {
            return subjectsService.DeleteSubject(_materia);
        }

    }
}