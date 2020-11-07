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

        [HttpGet]
        public String ListarPersonaNacionalidad()
        {
            try
            {
                return c_PersonaNacionalidadNegocio.ListarPersonaNacionalidad();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String InsertarPersonaNacionalidad(TMCCM_C_Persona_Nacionalidad personaNacionalidad)
        {
            try
            {
                c_PersonaNacionalidadNegocio.InsertarPersonaNacionalidad(personaNacionalidad);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}