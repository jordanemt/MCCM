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

        [HttpGet]
        public String ListarPersonaGenero()
        {

            return c_PersonaGeneroNegocio.ListarPersonaGenero();
        }
        [HttpPost]
        public String InsertarPersonaGenero(TMCCM_C_Persona_Genero personaGenero)
        {
            c_PersonaGeneroNegocio.InsertarPersonaGenero(personaGenero);
            return "S";
        }
    }
}