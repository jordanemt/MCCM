using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class C_TipoDrogaController : Controller
    {
        C_TipoDrogaNegocio c_TipoDrogaNegocio = new C_TipoDrogaNegocio();
        // GET: C_TipoDroga

        public JsonResult ListarTipoDroga()
        {

            return Json(c_TipoDrogaNegocio.ListarTiposDroga(), JsonRequestBehavior.AllowGet);
        }
      
    }
}