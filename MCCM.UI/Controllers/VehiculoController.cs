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
            TMCCM_Vehiculo newData = negocio.Insertar(data);
            return Json(new { Placa = newData.TC_Placa, ID = newData.TN_ID_Vehiculo });
        }

        [HttpPost]
        public ActionResult InsertarGrupo_Vehiculo(TMCCM_Grupo_Vehiculo data)
        {
            return PartialView("_Grupo_VehiculoCard", negocioGrupo_Vehiculo.Insertar(data));
        }

        [HttpPost]
        public ActionResult ActualizarGrupo_Vehiculo(TMCCM_Grupo_Vehiculo data)
        {
            return PartialView("_Grupo_VehiculoCard", negocioGrupo_Vehiculo.Actualizar(data));
        }

        [HttpPost]
        public void EliminarGrupo_Vehiculo(int id)
        {
            negocioGrupo_Vehiculo.EliminarPorId(id);
        }
    }
}