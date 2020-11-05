using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GenerarReporte() {
            CasoNegocio negocio = new CasoNegocio();
            ViewBag.eventos = negocio.ReporteDeEventos(15, DateTime.Now, DateTime.Now);
            ViewBag.tareas = negocio.ReporteDeTareas(15, DateTime.Now, DateTime.Now);
            ViewBag.entidades = negocio.ReporteDeEntidades(15, DateTime.Now, DateTime.Now);
            ViewBag.gastos = negocio.ReporteDeGastos(15, DateTime.Now, DateTime.Now);
            ViewBag.recursos = negocio.ReporteDeRecursos(15, DateTime.Now, DateTime.Now);
            return PartialView("_Reporte");
        }
    }
}