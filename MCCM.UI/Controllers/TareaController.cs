using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.ReglasNegocio;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;

namespace MCCM.UI.Controllers
{
    public class TareaController : Controller
    {

        TareaNegocio tareaNegocio = new TareaNegocio();
        // GET: Tarea
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String InsertarTarea(TMCCM_Tarea tarea)
        {
            tareaNegocio.InsertarTarea(tarea);
            return "S";
        }

        [HttpPost]
        public String ActualizarTarea(TMCCM_Tarea tarea)
        {
            tareaNegocio.ActualizarTarea(tarea);
            return "S";
        }

        [HttpGet]
        public String ListarTarea()
        {
            return JsonConvert.SerializeObject(tareaNegocio.ListarTarea(), Formatting.Indented);
        }
        [HttpGet]
        public string ObtenerTareaPorID(int ID)
        {
            return JsonConvert.SerializeObject(tareaNegocio.ObtenerTareaPorID(ID), Formatting.Indented);
        }

        [HttpPost]
        public string EliminarTareaPorID(int ID)
        {
            return tareaNegocio.EliminarTarea(ID);
        }
    }
}