using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_VehiculoMarcaController : Controller
    {
        C_VehiculoMarcaNegocio c_VehiculoMarcaNegocio = new C_VehiculoMarcaNegocio();
        [HttpGet]
        public String ListarVehiculoMarca()
        {

            return c_VehiculoMarcaNegocio.ListarVehiculoMarca();
        }
        [HttpPost]
        public String InsertarVehiculoMarca(TMCCM_C_Vehiculo_Marca vehiculMarca)
        {
            c_VehiculoMarcaNegocio.InsertarVehiculoMarca(vehiculMarca);
            return "S";
        }
    }
}