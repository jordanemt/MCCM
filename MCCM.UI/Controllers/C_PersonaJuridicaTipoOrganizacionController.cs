using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaJuridicaTipoOrganizacionController : Controller
    {
        C_PersonaJuridicaTipoOrganizacionNegocio c_PersonaJuridicaTipoOrganizacionNegocio = new C_PersonaJuridicaTipoOrganizacionNegocio();

        [HttpGet]
        public String ListarPersonaJuridicaTipoOrganizacion()
        {

            return c_PersonaJuridicaTipoOrganizacionNegocio.ListarPersonaJuridicaTipoOrganización();
        }
        [HttpPost]
        public String InsertarPersonaJuridicaTipoOrganizacion(TMCCM_C_Persona_Juridica_Tipo_Organización personaJuridicaTipoOrganizacion)
        {
            c_PersonaJuridicaTipoOrganizacionNegocio.InsertarPersonaJuridicaTipoOrganizacion(personaJuridicaTipoOrganizacion);
            return "S";
        }
    }
}