using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_TipoDrogaController : Controller
    {
        C_TipoDrogaNegocio c_TipoDrogaNegocio = new C_TipoDrogaNegocio();

        [HttpGet]
        public String ListarTipoDroga()
        {
            try { 
            return c_TipoDrogaNegocio.ListarTiposDroga();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarTipoDroga(TMCCM_C_Droga_Tipo_Droga tipoDroga)
        {
            try { 
            c_TipoDrogaNegocio.InsertarTipoDroga(tipoDroga);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}