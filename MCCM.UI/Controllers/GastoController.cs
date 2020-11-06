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
        private GastoNegocio negocio;
        private  EventoNegocio eventoNegocio;

        public GastoController()
        {
            negocio = new GastoNegocio();
            eventoNegocio = new EventoNegocio();
        }

        [HttpGet]
        public ActionResult InsertarFormModal()
        {
            ViewBag.TipoGasto = negocio.ListarTipoGasto();
            return PartialView("_InsertarFormModal");
        }

        [HttpGet]
        public ActionResult ActualizarFormModal(int id)
        {
            ViewBag.TipoGasto = negocio.ListarTipoGasto();
            return PartialView("_ActualizarFormModal", negocio.ObtenerPorId(id));
        }

        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                var model = negocio.Listar();
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
            return PartialView("_ListaCards", negocio.ListarPorCaso(idCaso));
        }

        [HttpPost]
        public ActionResult Insertar(TMCCM_Gasto data)
        {
            var model = negocio.Insertar(data);
            //InsertarEvento(model, "Se insertó");
            return PartialView("_Card", model);
        }

        [HttpPost]
        public ActionResult Actualizar(TMCCM_Gasto data)
        {
            var model = negocio.Actualizar(data);
            InsertarEvento(model, "Se actualizó");
            return PartialView("_Card", model);
        }

        [HttpPost]
        public void EliminarPorId(int id)
        {
            var model = negocio.ObtenerPorId(id);
            InsertarEvento(model, "Se eliminó");
            negocio.EliminarPorId(id);
        }

        [HttpPost]
        public ActionResult InsertarTipo_Gasto(TMCCM_C_Gasto_Tipo_Gasto data)
        {
            TMCCM_C_Gasto_Tipo_Gasto newData = negocio.InsertarTipo_Gasto(data);
            return Json(new { Nombre = newData.TC_Nombre, ID = newData.TN_ID_Tipo_Gasto });
        }

        [HttpGet]
        public ActionResult ObtenerSumatoriaDeGastosPorTipoPorCaso(int idCaso)
        {
            var lista = negocio.ListarPorCaso(idCaso);
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

        private void InsertarEvento(TMCCM_Gasto data, string accion) {
            TMCCM_Evento evento = new TMCCM_Evento();
            evento.TN_ID_Caso = data.TN_ID_Caso;
            evento.TC_Lugar = "Gastos Operativos";
            evento.TC_Informa = "MCCM";
            evento.TF_Fecha = DateTime.Now;
            evento.TC_Novedad =
                accion + " gasto #" + data.TN_ID_Gasto +
                " (Factura: " + data.TN_Num_Factura +
                ", Fecha: " + ((DateTime) data.TF_Fecha).ToString("dd/MM/yyyy") +
                ", Tipo: " + data.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre +
                ", Monto: " + data.TD_Monto +
                ", Detalle: " + data.TC_Compra + ")";
            eventoNegocio.InsertarEvento(evento);
        }
    }
}