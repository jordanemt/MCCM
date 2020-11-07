using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaSexoController : Controller
    {
        C_PersonaSexoNegocio c_PersonaSexoNegocio = new C_PersonaSexoNegocio();

        [HttpGet]
        public String ListarPersonaSexo()
        {
            try { 
            return c_PersonaSexoNegocio.ListarPersonaSexo();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarPersonaSexo(TMCCM_C_Persona_Sexo personaSexo)
        {
            try { 
            c_PersonaSexoNegocio.InsertarPersonaSexo(personaSexo);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}