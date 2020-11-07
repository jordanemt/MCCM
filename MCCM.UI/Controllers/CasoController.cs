using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;


namespace MCCM.UI.Controllers
{
    public class CasoController : Controller
    {

        CasoNegocio casoNegocio = new CasoNegocio();


        [HttpPost]
        public String InsertarCaso(TMCCM_Caso caso)
        {
            try
            {
                casoNegocio.InsertarCaso(caso);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String ActualizarCaso(TMCCM_Caso caso)
        {
            try
            {
                casoNegocio.ActualizarCaso(caso);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string ListarCasos()
        {
            try
            {
                return casoNegocio.ListarCasos();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string ObtenerCasoPorID(int ID)
        {
            try
            {
                return casoNegocio.ObtenerCasoPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public string EliminarCasoPorID(int ID)
        {
            try
            {
                return casoNegocio.EliminarCaso(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



    }
}