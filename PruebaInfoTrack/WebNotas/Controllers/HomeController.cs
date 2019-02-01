using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TST = PruebaInfoTrack;

namespace WebNotas.Controllers
{
    public class HomeController : Controller
    {
        TST.Controllers.EstudianteController EstudianteController = new TST.Controllers.EstudianteController();
        public ActionResult Index()
        {
            var estudiante = EstudianteController.GetAllStudents();
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
                       
            return View();
        }
    }
}