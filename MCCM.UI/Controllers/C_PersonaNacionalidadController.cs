using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaNacionalidadController : Controller
    {
        C_PersonaNacionalidadNegocio c_PersonaNacionalidadNegocio = new C_PersonaNacionalidadNegocio();

            public JsonResult ListarPersonaNacionalidad()
            {

                return Json(c_PersonaNacionalidadNegocio.ListarPersonaNacionalidad(), JsonRequestBehavior.AllowGet);
            }
        public String InsertarPersonaNacionalidad(TMCCM_C_Persona_Nacionalidad personaNacionalidad)
        {
            c_PersonaNacionalidadNegocio.InsertarPersonaNacionalidad(personaNacionalidad);
            return "S";
        }
    }
}