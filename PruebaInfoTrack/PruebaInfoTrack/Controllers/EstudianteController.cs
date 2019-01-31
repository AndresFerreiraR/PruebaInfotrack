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
    public class EstudianteController : Controller
    {
        private readonly IEstudiante studentService;

        public EstudianteController()
        {
            studentService = new Estudiante();
        }

        [Route("CrearEstudiante")]
        public JObject Create([FromBody] Alumno alumno)
        {
            return studentService.CreateStudent(alumno);
        }

        [Route("ActualizarEstudiante")]
        public JObject Update([FromBody] Alumno alumno)
        {
            return studentService.UpdateStudent(alumno);
        }

        [Route("ListarEstudiantes")]
        public JObject GetAllStudents()
        {
            return studentService.GetAllStudents();
        }

        [Route("BorrarEstudiante")]
        public JObject DeleteStudent([FromBody] Alumno alumno)
        {
            return studentService.DeleteStudent(alumno);
        }
    }
}