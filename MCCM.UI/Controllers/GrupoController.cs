using MCCM.Entidad;
using MCCM.ReglasNegocio;
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
        public ActionResult CargarModal()
        {
            return PartialView("_FormModal");
        }

        [HttpGet]
        public ActionResult CargarModalConId(int id)
        {
            return PartialView("_FormModal", grupoNegocio.ObtenerPorId(id));
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var model = grupoNegocio.Listar();
            return PartialView("_Lista", model);
        }

        [HttpPost]
        public ActionResult Insertar(TMCCM_Grupo data)
        {
            return PartialView("_Gasto", grupoNegocio.Insertar(data));
        }

        [HttpPost]
        public ActionResult Actualizar(TMCCM_Grupo data)
        {
            return PartialView("_Gasto", grupoNegocio.Actualizar(data));
        }

        [HttpPost]
        public void EliminarPorId(int id)
        {
            grupoNegocio.EliminarPorId(id);
        }
    }
}