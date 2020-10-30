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
        public ActionResult Grupo_VehiculoActualizarFormModal(int idGrupo, int idVehiculo)
        {
            ViewBag.Grupo_Vehiculo = negocioGrupo_Vehiculo.ObtenerPorId(idGrupo, idVehiculo);
            return PartialView("_Grupo_VehiculoActualizarFormModal", negocio.Listar());
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
        public ActionResult DevolverGrupo_Vehiculo(int idGrupo, int idVehiculo, int kmRegreso)
        {
            TMCCM_Grupo_Vehiculo e = negocioGrupo_Vehiculo.ObtenerPorId(idGrupo, idVehiculo);
            e.TN_Km_Regreso = kmRegreso;
            return PartialView("_Grupo_VehiculoCard", negocioGrupo_Vehiculo.Devolver(e));
        }
    }
}