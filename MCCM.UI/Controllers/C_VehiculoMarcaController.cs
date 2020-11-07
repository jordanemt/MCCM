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
            try { 

            return c_VehiculoMarcaNegocio.ListarVehiculoMarca();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarVehiculoMarca(TMCCM_C_Vehiculo_Marca vehiculMarca)
        {
            try { 
            c_VehiculoMarcaNegocio.InsertarVehiculoMarca(vehiculMarca);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}