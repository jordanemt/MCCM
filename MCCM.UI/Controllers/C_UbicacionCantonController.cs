using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_UbicacionCantonController : Controller
    {
        C_UbicacionCantonNegocio c_UbicacionCantonNegocio = new C_UbicacionCantonNegocio();

        [HttpGet]
        public String ListarUbicacionCanton(int idProvincia)
        {

            return c_UbicacionCantonNegocio.ListarUbicacionCanton(idProvincia);
        }
        [HttpPost]
        public String InsertarUbicacionCanton(TMCCM_C_Ubicacion_Canton ubicacionCanton)
        {
            c_UbicacionCantonNegocio.InsertarUbicacionCanton(ubicacionCanton);
            return "S";
        }
    }
}