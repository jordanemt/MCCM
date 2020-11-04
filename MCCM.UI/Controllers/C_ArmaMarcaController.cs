using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_ArmaMarcaController : Controller
    {
        C_ArmaMarcaNegocio c_ArmaMarcaNegocio = new C_ArmaMarcaNegocio();

        [HttpGet]
        public string ListarArmaMarca()
        {

            return c_ArmaMarcaNegocio.ListaArmaMarca();
        }

        [HttpPost]
        public String InsertarArmaMarca(TMCCM_C_Arma_Marca armaMarca)
        {
            c_ArmaMarcaNegocio.InsertarArmaMarca(armaMarca);
            return "S";
        }
    }
}