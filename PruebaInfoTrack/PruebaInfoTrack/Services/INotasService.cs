using Newtonsoft.Json.Linq;
using PruebaInfoTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInfoTrack.Services
{
    public interface INotasService
    {
        JObject CreateScore(Notas notas);
        JObject UpdateScore(Notas notas);
        JObject DeleteScore(Notas notas);
        JObject GetAllScores();
    }
}
