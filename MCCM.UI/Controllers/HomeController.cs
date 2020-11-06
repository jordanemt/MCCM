using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;


namespace MCCM.UI.Controllers
{
    public class HomeController : Controller
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

    }
}