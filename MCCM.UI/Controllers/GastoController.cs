using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult InsertarFormModal()
        {
            ViewBag.TipoGasto = gastoNegocio.ListarTipoGasto();
            return PartialView("_InsertarFormModal");
        }

        [HttpGet]
        public ActionResult ActualizarFormModal(int id)
        {
            ViewBag.TipoGasto = gastoNegocio.ListarTipoGasto();
            return PartialView("_ActualizarFormModal", gastoNegocio.ObtenerPorId(id));
        }

        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                var model = gastoNegocio.Listar();
                return PartialView("_ListaCards", model);
            }
            catch (Exception e)
            {
                return Content(e.Message, "text");
            }
        }

        [HttpGet]
        public ActionResult ListarPorCasoId(int idCaso)
        {
            return PartialView("_ListaCards", gastoNegocio.ListarPorCaso(idCaso));
        }

        [HttpPost]
        public ActionResult Insertar(TMCCM_Gasto data)
        {
            return PartialView("_Card", gastoNegocio.Insertar(data));
        }

        [HttpPost]
        public ActionResult Actualizar(TMCCM_Gasto data)
        {
            return PartialView("_Card", gastoNegocio.Actualizar(data));
        }

        [HttpPost]
        public void EliminarPorId(int id)
        {
            gastoNegocio.EliminarPorId(id);
        }

        [HttpPost]
        public ActionResult InsertarTipo_Gasto(TMCCM_C_Gasto_Tipo_Gasto data)
        {
            TMCCM_C_Gasto_Tipo_Gasto newData = gastoNegocio.InsertarTipo_Gasto(data);
            return Json(new { Nombre = newData.TC_Nombre, ID = newData.TN_ID_Tipo_Gasto });
        }

        [HttpGet]
        public ActionResult ObtenerSumatoriaDeGastosPorTipoPorCaso(int idCaso)
        {
            var lista = gastoNegocio.ListarPorCaso(idCaso);
            var totalPorTipos =
                from grupo in lista
                group grupo by grupo.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre into grupoGroup
                select new 
                {
                    nombre = grupoGroup.Key,
                    totalTipo = grupoGroup.Sum(e => e.TD_Monto)
                };
            var total = totalPorTipos.Sum(e => e.totalTipo);
            return Json(new { tiposSumatoria = totalPorTipos, total }, JsonRequestBehavior.AllowGet);
        }
    }
}