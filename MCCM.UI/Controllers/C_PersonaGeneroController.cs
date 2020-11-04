using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaGeneroController : Controller
    {
        C_PersonaGeneroNegocio c_PersonaGeneroNegocio = new C_PersonaGeneroNegocio();

        public JsonResult ListarPersonaGenero()
        {

            return Json(c_PersonaGeneroNegocio.ListarPersonaGenero(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public String InsertarPersonaGenero(TMCCM_C_Persona_Genero personaGenero)
        {
            c_PersonaGeneroNegocio.InsertarPersonaGenero(personaGenero);
            return "S";
        }
    }
}