using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_VehiculoColorController : Controller
    {
        C_VehiculoColorNegocio c_VehiculoColorNegocio = new C_VehiculoColorNegocio();

        public String ListarVehiculoColor()
        {

            return c_VehiculoColorNegocio.ListarVehiculoColor();
        }
        public String InsertarVehiculoColor(TMCCM_C_Vehiculo_Color vehiculoColor)
        {
            c_VehiculoColorNegocio.InsertarVehiculoColor(vehiculoColor);
            return "S";
        }
    }
}