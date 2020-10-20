using MCCM.Entidad;
using MCCM.ReglasNegocio;
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
        public ActionResult CargarModal()
        {
            ViewBag.TipoGasto = gastoNegocio.ListarTipoGasto();
            return PartialView("_FormModal");
        }

        [HttpGet]
        public ActionResult CargarModalGastoId(int id)
        {
            ViewBag.TipoGasto = gastoNegocio.ListarTipoGasto();
            return PartialView("_FormModal", gastoNegocio.ObtenerPorId(id));
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var model = gastoNegocio.Listar();
            return PartialView("_Lista", model);
        }

        [HttpPost]
        public ActionResult Insertar(TMCCM_Gasto data)
        {
            return PartialView("_Gasto", gastoNegocio.Insertar(data));
        }

        [HttpPost]
        public ActionResult Actualizar(TMCCM_Gasto data)
        {
            return PartialView("_Gasto", gastoNegocio.Actualizar(data));
        }

        [HttpPost]
        public void EliminarPorId(int id)
        {
            gastoNegocio.EliminarPorId(id);
        }
    }
}