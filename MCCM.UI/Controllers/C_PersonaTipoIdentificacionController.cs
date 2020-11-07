using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaTipoIdentificacionController : Controller
    {
        C_PersonaTipoIdentificacionNegocio c_PersonaTipoIdentificacionNegocio = new C_PersonaTipoIdentificacionNegocio();

        [HttpGet]
        public String ListarPersonaTipoIdentificacion()
        {
            try { 

            return c_PersonaTipoIdentificacionNegocio.ListarPersonaTipoIdentificacion();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String InsertarPersonaTipoIdentificacion(TMCCM_C_Persona_Tipo_Identificacion persona_Tipo_Identificacion)
        {
            try { 
            c_PersonaTipoIdentificacionNegocio.InsertarPersonaTipoIdentificacion(persona_Tipo_Identificacion);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}