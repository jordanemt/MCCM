using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class E_DrogaController : Controller
    {
        EntidadDrogaNegocio entidadDrogaNegocio = new EntidadDrogaNegocio();
        // GET: E_Droga
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Insertar_E_Droga(TMCCM_Entidad_Droga entidadDroga, int caso)
        {
            entidadDroga.TN_ID_Caso = caso;
            entidadDrogaNegocio.InsertarEntidadDroga(entidadDroga);
            return "S";
        }
        [HttpGet]
        public String Listar_E_Droga(int caso)
        {
            return JsonConvert.SerializeObject(entidadDrogaNegocio.ListarEntidadDrogas(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_DrogaPorID(int entidadDrogaID)
        {
            return entidadDrogaNegocio.EliminarEntidadDroga(entidadDrogaID);
        }
        [HttpPost]
        public String Modificar_E_Droga(TMCCM_Entidad_Droga entidadDroga)
        {
            entidadDrogaNegocio.ActualizarEntidadDroga(entidadDroga);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_DrogaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadDrogaNegocio.ObtenerEntidadDrogaPorID(ID), Formatting.Indented);
        }
    }
}