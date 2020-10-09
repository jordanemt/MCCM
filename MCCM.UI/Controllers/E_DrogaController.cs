using MCCM.Entidad;
using MCCM.ReglasNegocio;
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
        public String Insertar_E_Droga(TMCCM_Entidad_Droga entidad_Droga)
        {

            entidadDrogaNegocio.InsertarEntidadDroga(entidad_Droga);
            return "S";
        }
    }
}