using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_VehiculoClaseController : Controller
    {
        C_VehiculoClaseNegocio c_VehiculoClaseNegocio = new C_VehiculoClaseNegocio();
        [HttpGet]
        public String ListarVehiculoClase()
        {
            try { 
            return c_VehiculoClaseNegocio.ListarVehiculoClase();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarVehiculoClase(TMCCM_C_Vehiculo_Clase vehiculoClase)
        {
            try { 
            c_VehiculoClaseNegocio.InsertarVehiculoClase(vehiculoClase);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}