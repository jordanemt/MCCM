using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class DashboardController : Controller
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Salir()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Dashboard");
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult VerificarUsuario(string Usuario, string contrasennia)
        {
            var oUser = usuarioNegocio.Verificar(Usuario, contrasennia);
            if (oUser == null)
            {
                ViewBag.Error = "Usuario o contrase;a invalida";
                return RedirectToAction("Login", "Dashboard");
            }
            Session["User"] = oUser;
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        public int ObtenerRolUsuario() { 
            TMCCM_Usuario usuario= (TMCCM_Usuario)HttpContext.Session["User"];
            return usuario.TMCCM_Rol.FirstOrDefault<TMCCM_Rol>().TN_ID_Rol;
        } 

        [HttpGet]
        public ActionResult GenerarReporte(ReporteRequest request) {
            CasoNegocio negocio = new CasoNegocio();
            var eventos = negocio.ReporteDeEventos(request.CasoID, request.Inicio, request.Final, request.Eventos);
            var tareas = negocio.ReporteDeTareas(request.CasoID, request.Inicio, request.Final, 
                request.TareasTerminadas, request.TareasPendientes);
            var entidades = negocio.ReporteDeEntidades(request.CasoID, request.Inicio, request.Final, 
                request.Persona, request.PersonaJuridica, request.EntidadVehiculo, request.Ubicacion, 
                request.Telefono, request.Arma, request.Droga);
            var gastos = negocio.ReporteDeGastos(request.CasoID, request.Inicio, request.Final, 
                request.Operativo, request.Combustible);
            var recursos = negocio.ReporteDeRecursos(request.CasoID, request.Inicio, request.Final, 
                request.Personal, request.Vehiculo);

            return Json(new {
                eventos,
                tareas,
                entidades,
                gastos,
                recursos
            }, JsonRequestBehavior.AllowGet);
        }

        public class ReporteRequest
        {
            public int CasoID { get; set; }
            public DateTime Inicio { get; set; }
            public DateTime Final { get; set; }
            public bool Eventos { get; set; }
            public bool TareasTerminadas { get; set; }
            public bool TareasPendientes { get; set; }
            public bool Persona { get; set; }
            public bool PersonaJuridica { get; set; }
            public bool EntidadVehiculo { get; set; }
            public bool Ubicacion { get; set; }
            public bool Telefono { get; set; }
            public bool Arma { get; set; }
            public bool Droga { get; set; }
            public bool Operativo { get; set; }
            public bool Combustible { get; set; }
            public bool Personal { get; set; }
            public bool Vehiculo { get; set; }
        }
    }
}