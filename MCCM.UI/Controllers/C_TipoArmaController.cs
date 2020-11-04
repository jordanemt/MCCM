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

            return c_TipoArmaNegocio.ListaTipoArma();
        }
        [HttpPost]
        public String InsertarTipoArma(TMCCM_C_Arma_Tipo_Arma tipoArma)
        {
            c_TipoArmaNegocio.InsertarTipoArma(tipoArma);
            return "S";
        }
    }
}