using MCCM.Entidad;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class GrupoController : Controller
    {
        private GrupoNegocio grupoNegocio;

        public GrupoController()
        {
            grupoNegocio = new GrupoNegocio();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = grupoNegocio.GetAll();
            return PartialView("_List", model);
        }

        [HttpGet]
        public TMCCM_Grupo GetById(int id)
        {
            return grupoNegocio.GetById(id);
        }

        [HttpGet]
        public ActionResult AddVehiculo(int idGrupo, int idVehiculo, string fecha)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Insert(TMCCM_Grupo data)
        {
            grupoNegocio.Insert(data);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Update(TMCCM_Grupo data)
        {
            grupoNegocio.Update(data);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            grupoNegocio.DeleteById(id);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}