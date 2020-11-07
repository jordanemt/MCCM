using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_TipoArmaController : Controller
    {
        C_TipoArmaNegocio c_TipoArmaNegocio = new C_TipoArmaNegocio();

        [HttpGet]
        public String ListarTipoArma()
        {
            try { 

            return c_TipoArmaNegocio.ListaTipoArma();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarTipoArma(TMCCM_C_Arma_Tipo_Arma tipoArma)
        {
            try { 
            c_TipoArmaNegocio.InsertarTipoArma(tipoArma);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}