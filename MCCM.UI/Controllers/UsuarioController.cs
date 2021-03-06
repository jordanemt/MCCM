﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.ReglasNegocio;
using MCCM.UI.Filters;
using Newtonsoft.Json;
namespace MCCM.UI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        // GET: Usuario
        //[Autentificacion(idRol: 1)]
        public ActionResult ListaUsuario()
        {
            return View(usuarioNegocio.Listar());
        }
        public ActionResult InsertarUsuario()
        {
            return View();
        }
        public ActionResult ModificarUsuario(int id)
        {
            return View(usuarioNegocio.ObtenerPorID(id));
        }

        [HttpPost]
        public ActionResult InsertarUsuario(TMCCM_Usuario usuario)
        {
            usuarioNegocio.Insertar(usuario);
            return View("ListaUsuario", usuarioNegocio.Listar());
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(TMCCM_Usuario usuario)
        {
            usuarioNegocio.Actualizar(usuario);
            return View("ListaUsuario", usuarioNegocio.Listar());
        }

        [HttpGet]
        public IEnumerable<TMCCM_Usuario> ListarUsuario()
        {
            return usuarioNegocio.Listar();
        }

        [HttpGet]
        public string ObtenerUsuarioPorID(int ID)
        {
            return JsonConvert.SerializeObject(usuarioNegocio.ObtenerPorID(ID), Formatting.Indented);
        }

        [HttpGet]
        public ActionResult EliminarUsuarioPorID(int id)
        {
            usuarioNegocio.EliminarPorID(id);
            return View("ListaUsuario", usuarioNegocio.Listar()) ;
        }


    }
}