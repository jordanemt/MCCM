using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.ReglasNegocio;
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
        public String InsertarTarea(TMCCM_Tarea tarea,DateTime TF_Fecha, int caso)
        {
            tarea.TF_Fecha = TF_Fecha;
            tarea.TN_ID_Caso = caso;
            tareaNegocio.InsertarTarea(tarea);
            return "S";
        }

        [HttpPost]
        public String ModificarTarea(TMCCM_Tarea tarea,DateTime fecha)
        {
            tarea.TF_Fecha = fecha;
            tareaNegocio.ModificarTarea(tarea);
            return "S";
        }

        [HttpGet]
        public String ListarTarea(int caso)
        {
            return tareaNegocio.ListarTarea(caso);
        }

        [HttpGet]
        public string ObtenerTareaPorID(int ID)
        {
            return tareaNegocio.ObtenerTareaPorID(ID);
        }

        [HttpGet]
        public string ObtenerCatalogoUsuarios()
        {
            return tareaNegocio.ObtenerCatalogoUsuarios();
        }
        

       [HttpPost]
        public string EliminarTareaPorID(int tareaID)
        {
            return tareaNegocio.EliminarTarea(tareaID);
        }
    }
}