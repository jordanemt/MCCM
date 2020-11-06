using MCCM.Entidad;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class VehiculoController : Controller
    {
        private VehiculoNegocio negocio = new VehiculoNegocio();
        private Grupo_VehiculoNegocio negocioGrupo_Vehiculo = new Grupo_VehiculoNegocio();
        private EventoNegocio eventoNegocio = new EventoNegocio();

        [HttpGet]
        public ActionResult Grupo_VehiculoInsertarFormModal()
        {
            return PartialView("_Grupo_VehiculoInsertarFormModal", negocio.Listar());
        }

        [HttpGet]
        public ActionResult Grupo_VehiculoActualizarFormModal(int id)
        {
            ViewBag.Grupo_Vehiculo = negocioGrupo_Vehiculo.ObtenerPorId(id);
            return PartialView("_Grupo_VehiculoActualizarFormModal");
        }

        [HttpGet]
        public ActionResult ListarGrupo_Vehiculo()
        {
            var model = negocioGrupo_Vehiculo.Listar();
            return PartialView("_Grupo_VehiculoListaCards", model);
        }

        [HttpGet]
        public ActionResult ListarGrupo_VehiculoPorGrupoId(int idGrupo)
        {
            var model = negocioGrupo_Vehiculo.ListarPorGrupoId(idGrupo);
            return PartialView("_Grupo_VehiculoListaCards", model);
        }

        [HttpPost]
        public ActionResult InsertarVehiculo(TMCCM_Vehiculo data)
        {
            try
            {
                TMCCM_Vehiculo newData = negocio.Insertar(data);
                return Json(new { Placa = newData.TC_Placa, ID = newData.TN_ID_Vehiculo });
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public ActionResult InsertarGrupo_Vehiculo(TMCCM_Grupo_Vehiculo data)
        {
            var model = negocioGrupo_Vehiculo.Insertar(data);
            InsertarEvento(model, "Se insertó");
            return PartialView("_Grupo_VehiculoCard", model);
        }

        [HttpPost]
        public ActionResult ActualizarGrupo_Vehiculo(TMCCM_Grupo_Vehiculo data)
        {
            var model = negocioGrupo_Vehiculo.Actualizar(data);
            InsertarEvento(model, "Se actualizó");
            return PartialView("_Grupo_VehiculoCard", model);
        }

        [HttpPost]
        public void EliminarGrupo_Vehiculo(int id)
        {
            var model = negocioGrupo_Vehiculo.ObtenerPorId(id);
            InsertarEvento(model, "Se eliminó");
            negocioGrupo_Vehiculo.EliminarPorId(id);
        }

        private void InsertarEvento(TMCCM_Grupo_Vehiculo data, string accion)
        {
            TMCCM_Evento evento = new TMCCM_Evento();
            evento.TN_ID_Caso = data.TMCCM_Grupo.TN_ID_Caso;
            evento.TC_Lugar = "Vehículos de grupo #" + data.TMCCM_Grupo.TN_ID_Grupo;
            evento.TC_Informa = "MCCM";
            evento.TF_Fecha = DateTime.Now;
            evento.TC_Novedad =
                accion + " vehículo #" + data.TMCCM_Vehiculo.TC_Placa +
                " (Km/Inicio: " + data.TN_Km_Inicio +
                ", Km/Regreso: " + ((data.TN_Km_Regreso != null) ? data.TN_Km_Regreso.ToString() : "---") +
                ", Fecha/Hora: " + ((DateTime)data.TF_Fecha_Hora).ToString("dd/MM/yyyy HH:mm") + ")";
            eventoNegocio.InsertarEvento(evento);
        }
    }
}