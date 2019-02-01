using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScore.Models;

namespace WebScore.Controllers
{
    public class HomeController : Controller
    {
        PruebaInfoTrack.Controllers.EstudianteController esrudiantes = new PruebaInfoTrack.Controllers.EstudianteController();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getEstudents()
        {
            var result = esrudiantes.GetAllStudents();
            return Json(result);
        }
    }
}
