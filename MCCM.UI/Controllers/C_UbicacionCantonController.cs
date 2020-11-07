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
            try { 

            return c_UbicacionCantonNegocio.ListarUbicacionCanton(idProvincia);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarUbicacionCanton(TMCCM_C_Ubicacion_Canton ubicacionCanton)
        {
            try { 
            c_UbicacionCantonNegocio.InsertarUbicacionCanton(ubicacionCanton);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}