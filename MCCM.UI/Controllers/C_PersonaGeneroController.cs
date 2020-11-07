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
            try { 
            return c_PersonaGeneroNegocio.ListarPersonaGenero();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarPersonaGenero(TMCCM_C_Persona_Genero personaGenero)
        {
            try { 
            c_PersonaGeneroNegocio.InsertarPersonaGenero(personaGenero);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}