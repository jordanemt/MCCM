using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class DashboardController : Controller
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Salir()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Dashboard");
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult VerificarUsuario(string Usuario, string contrasennia)
        {

            var oUser = usuarioNegocio.Verificar(Usuario, contrasennia);
            if (oUser == null)
            {
                ViewBag.Error = "Usuario o contrase;a invalida";
                return RedirectToAction("Login", "Dashboard");
            }
            Session["User"] = oUser;




            return RedirectToAction("Index", "Dashboard");



        }
    }
}