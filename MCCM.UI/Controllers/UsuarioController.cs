using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult ListaUsuario()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }
        public ActionResult ActualizarUsuario()
        {
            return View();
        }

    }
}