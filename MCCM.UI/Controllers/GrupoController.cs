using MCCM.Entidad;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class GrupoController : Controller
    {
        private GrupoNegocio negocio;
        private UsuarioNegocio usuarioNegocio;
        private EventoNegocio eventoNegocio;

        public GrupoController()
        {
            negocio = new GrupoNegocio();
            usuarioNegocio = new UsuarioNegocio();
            eventoNegocio = new EventoNegocio();
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
            return PartialView("_ListaCards", model);
        }

        [HttpGet]
        public ActionResult ListarPorCasoId(int idCaso)
        {
            return PartialView("_ListaCards", negocio.ListarPorCaso(idCaso));
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
            var model = negocio.Insertar(data);
            InsertarEvento(model, "Se insertó");
            return PartialView("_Card", model);
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

        private void InsertarEvento(TMCCM_Grupo data, string accion)
        {
            TMCCM_Usuario encargado = data.TMCCM_Grupo_Usuario.Where(e => e.TB_Encargado == true).FirstOrDefault().TMCCM_Usuario;
            List<TMCCM_Usuario> acompannantes = data.TMCCM_Grupo_Usuario.Where(e => e.TB_Encargado == false).Select(e => e.TMCCM_Usuario).ToList();

            string encargadoMsg = "Encargado: " + encargado.TN_ID_Usuario + " " + encargado.TC_Nombre + " " + encargado.TC_Primer_Apellido;
            string acompannantesMsg = "";

            foreach (TMCCM_Usuario acompannante in acompannantes) 
            {
                acompannantesMsg += (acompannante.TN_ID_Usuario == acompannantes.FirstOrDefault().TN_ID_Usuario) ? "Acompañantes: " : "; ";
                acompannantesMsg += acompannante.TN_ID_Usuario + " " + acompannante.TC_Nombre + " " + acompannante.TC_Primer_Apellido;
            }

            TMCCM_Evento evento = new TMCCM_Evento();
            evento.TN_ID_Caso = data.TN_ID_Caso;
            evento.TC_Lugar = "Grupos";
            evento.TC_Informa = "MCCM";
            evento.TF_Fecha = DateTime.Now;
            evento.TC_Novedad =
                accion + " grupo #" + data.TN_ID_Grupo +
                " (Zona: " + data.TC_Zona +
                ", Fecha/Inicio: " + ((DateTime)data.TF_Fecha_Inicio).ToString("dd/MM/yyyy") +
                ", Fecha/Final: " + ((data.TF_Fecha_Final != null)? ((DateTime)data.TF_Fecha_Inicio).ToString("dd/MM/yyyy"):"---") +
                ", Hora: " + data.TF_Hora +
                ", Tipo: " + (((bool)data.TB_Mando)? "Mando":"Operativo") +
                ", " + encargadoMsg + 
                ", " + acompannantesMsg + ")";
            eventoNegocio.InsertarEvento(evento);
        }
    }
}