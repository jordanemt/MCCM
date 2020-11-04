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

        public String ListarVehiculoClase()
        {

            return c_VehiculoClaseNegocio.ListarVehiculoClase();
        }
        public String InsertarVehiculoClase(TMCCM_C_Vehiculo_Clase vehiculoClase)
        {
            c_VehiculoClaseNegocio.InsertarVehiculoClase(vehiculoClase);
            return "S";
        }
    }
}