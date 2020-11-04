using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_UbicacionDistritoController : Controller
    {
        C_UbicacionDistritoNegocio c_UbicacionDistritoNegocio = new C_UbicacionDistritoNegocio();

        [HttpGet]
        public String ListarUbicacionDistrito(int idCanton)
        {

            return c_UbicacionDistritoNegocio.ListarUbicacionDistrito(idCanton);
        }
        [HttpPost]
        public String InsertarUbicacionDistrito(TMCCM_C_Ubicacion_Distrito ubicacionDistrito)
        {
            c_UbicacionDistritoNegocio.InsertarUbicacionDistrito(ubicacionDistrito);
            return "S";
        }
    }
}