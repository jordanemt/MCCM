using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class E_UbicacionController : Controller
    {
        EntidadUbicacionNegocio entidadUbicacionNegocio = new EntidadUbicacionNegocio();
        // GET: Ubicacion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Insertar_E_Ubicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
         
            entidadUbicacionNegocio.InsertarEntidadUbicacion(entidadUbicacion);
            return "S";
        }
    }
}