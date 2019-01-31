using Newtonsoft.Json.Linq;
using PruebaInfoTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInfoTrack.Services
{
    public interface IMateriaService
    {
        JObject CreateSubject(Materia materia);
        JObject UpdateSubject(Materia materia);
        JObject DeleteSubject(Materia materia);
        JObject GetAllSubjects();
    }
}
