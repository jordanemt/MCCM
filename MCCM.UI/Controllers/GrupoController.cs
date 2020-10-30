using MCCM.Entidad;
using MCCM.ReglasNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class GrupoController : Controller
    {
        private GrupoNegocio negocio;
        private UsuarioNegocio usuarioNegocio;

        public GrupoController()
        {
            negocio = new GrupoNegocio();
            usuarioNegocio = new UsuarioNegocio();
        }

        [HttpGet]
        public ActionResult InsertarFormModal()
        {
            ViewBag.Usuarios = usuarioNegocio.Listar();
            return PartialView("_InsertarFormModal");
        }

        [HttpGet]
        public ActionResult ActualizarFormModal(int id)
        {
            TMCCM_Grupo grupo = negocio.ObtenerPorId(id);
            TMCCM_Usuario encargado = grupo.TMCCM_Grupo_Usuario.Where(e => e.TB_Encargado == true).Select(e => e.TMCCM_Usuario).FirstOrDefault();
            List<TMCCM_Usuario> acompannantes = grupo.TMCCM_Grupo_Usuario.Where(e => e.TB_Encargado != true).Select(e => e.TMCCM_Usuario).ToList();
            List<TMCCM_Usuario> usuarios = usuarioNegocio.Listar();

            usuarios.Remove(usuarios.Where(e => e.TN_ID_Usuario == encargado.TN_ID_Usuario).FirstOrDefault());
            foreach (TMCCM_Usuario acompannante in acompannantes)
            {
                usuarios.Remove(usuarios.Where(e => e.TN_ID_Usuario == acompannante.TN_ID_Usuario).FirstOrDefault());
            }

            ViewBag.Usuarios = usuarios;
            ViewBag.Encargado = encargado;
            ViewBag.Acompannantes = acompannantes;

            return PartialView("_ActualizarFormModal", grupo);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var model = negocio.Listar();
            return PartialView("_Lista", model);
        }

        [HttpPost]
        public ActionResult Insertar(TMCCM_Grupo data, int Encargado, List<int> Acompannantes)
        {
            TMCCM_Grupo_Usuario item = new TMCCM_Grupo_Usuario();
            item.TN_ID_Usuario = Encargado;
            item.TB_Encargado = true;
            item.TB_Eliminado = false;
            data.TMCCM_Grupo_Usuario.Add(item);

            foreach (int idUsuario in Acompannantes)
            {
                item = new TMCCM_Grupo_Usuario();
                item.TN_ID_Usuario = idUsuario;
                item.TB_Encargado = false;
                item.TB_Eliminado = false;
                data.TMCCM_Grupo_Usuario.Add(item);
            }
            return PartialView("_Card", negocio.Insertar(data));
        }

        [HttpPost]
        public ActionResult Actualizar(TMCCM_Grupo data, int Encargado, List<int> Acompannantes)
        {
            TMCCM_Grupo_Usuario item = new TMCCM_Grupo_Usuario();
            item.TN_ID_Grupo = data.TN_ID_Grupo;
            item.TN_ID_Usuario = Encargado;
            item.TB_Encargado = true;
            item.TB_Eliminado = false;
            data.TMCCM_Grupo_Usuario.Add(item);

            foreach (int idUsuario in Acompannantes)
            {
                item = new TMCCM_Grupo_Usuario();
                item.TN_ID_Grupo = data.TN_ID_Grupo;
                item.TN_ID_Usuario = idUsuario;
                item.TB_Encargado = false;
                item.TB_Eliminado = false;
                data.TMCCM_Grupo_Usuario.Add(item);
            }
            return PartialView("_Card", negocio.Actualizar(data));
        }

        [HttpPost]
        public void EliminarPorId(int id)
        {
            negocio.EliminarPorId(id);
        }
    }
}