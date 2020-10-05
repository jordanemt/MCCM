using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;


namespace MCCM.UI.Controllers
{
    public class CasoController : Controller
    {

        CasoNegocio casoNegocio = new CasoNegocio();
        // GET: Caso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String InsertarCaso(TMCCM_Caso caso) {
            casoNegocio.InsertarCaso(caso);
            return "S";
        }

        [HttpPost]
        public String ActualizarCaso(TMCCM_Caso caso)
        {
            casoNegocio.ActualizarCaso(caso);
            return "S";
        }

        [HttpGet]
        public String ListarCasos() {
            return JsonConvert.SerializeObject(casoNegocio.ListarCasos(), Formatting.Indented);
        }
        [HttpGet]
        public string ObtenerCasoPorID(int ID) {
            return JsonConvert.SerializeObject(casoNegocio.ObtenerCasoPorID(ID), Formatting.Indented);
        }

        [HttpPost]
        public string EliminarCasoPorID(int ID)
        {
            return casoNegocio.EliminarCaso(ID);
        }



    }
}