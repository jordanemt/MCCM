using MCCM.Entidad;
using MCCM.ReglasNegocio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class GastoController : Controller
    {
        private GastoNegocio gastoNegocio;

        public GastoController()
        {
            gastoNegocio = new GastoNegocio();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = gastoNegocio.GetAll();
            return PartialView("_List", model);
        }

        [HttpGet]
        public TMCCM_Gasto GetById(int id)
        {
            return gastoNegocio.GetById(id);
        }

        [HttpPost]
        public ActionResult Insert(TMCCM_Gasto data)
        {
            gastoNegocio.Insert(data);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Update(TMCCM_Gasto data)
        {
            gastoNegocio.Update(data);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            gastoNegocio.DeleteById(id);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}