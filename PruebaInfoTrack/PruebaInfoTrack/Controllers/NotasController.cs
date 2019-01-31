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
    public class NotasController : Controller
    {
        private readonly INotasService scoreService;

        public NotasController()
        {
            scoreService = new NotasService();
        }

        [Route("RegistrarNota")]
        public JObject CreateScore([FromBody] Notas _nota)
        {
            return scoreService.CreateScore(_nota);
        }

        [Route("ActualizarNota")]
        public JObject UpdateScore([FromBody] Notas _nota)
        {
            return scoreService.UpdateScore(_nota);
        }

        [Route("ListarNotas")]
        public JObject GetAllScores()
        {
            return scoreService.GetAllScores();
        }

        [Route("BorrarNota")]
        public JObject DeleteScore([FromBody] Notas _nota)
        {
            return scoreService.DeleteScore(_nota);
        }

    }
}