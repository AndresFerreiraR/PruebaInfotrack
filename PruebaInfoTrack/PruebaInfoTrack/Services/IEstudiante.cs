using Newtonsoft.Json.Linq;
using PruebaInfoTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInfoTrack.Services
{
    public interface IEstudiante
    {
        JObject CreateStudent(Alumno alumno);
        JObject UpdateStudent(Alumno alumno);
        JObject DeleteStudent(Alumno alumno);
        JObject GetAllStudents();
    }
}
