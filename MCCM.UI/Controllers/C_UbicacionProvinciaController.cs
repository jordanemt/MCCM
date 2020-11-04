using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_UbicacionProvinciaController : Controller
    {
        C_UbicacionProvinciaNegocio c_UbicacionProvinciaNegocio = new C_UbicacionProvinciaNegocio();

        [HttpGet]
        public String ListarUbicacionProvincia()
        {

            return c_UbicacionProvinciaNegocio.ListarUbicacionProvincia();
        }
        [HttpPost]
        public String InsertarUbicacionProvincia(TMCCM_C_Ubicacion_Provincia ubicacionProvincia)
        {
            c_UbicacionProvinciaNegocio.InsertarUbicacionProvincia(ubicacionProvincia);
            return "S";
        }
    }
}