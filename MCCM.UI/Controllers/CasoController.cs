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
        public string ListarCasos() {
            return casoNegocio.ListarCasos();
        }
        [HttpGet]
        public string ObtenerCasoPorID(int ID) {
            return casoNegocio.ObtenerCasoPorID(ID);
        }

        [HttpPost]
        public string EliminarCasoPorID(int ID)
        {
            return casoNegocio.EliminarCaso(ID);
        }



    }
}