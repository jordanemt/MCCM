using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MCCM.UI.Controllers
{
    public class EventoController : Controller
    {
        EventoNegocio eventoNegocio = new EventoNegocio();

        [HttpPost]
        public String InsertarEvento(TMCCM_Evento evento,int caso)
        {
            try
            {
                evento.TN_ID_Caso = caso;
                eventoNegocio.InsertarEvento(evento);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String ModificarEvento(TMCCM_Evento evento)
        {
            try
            {
                eventoNegocio.ActualizarEvento(evento);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String EliminarEventoPorID(int eventoID) {
            try {
                return eventoNegocio.EliminarEvento(eventoID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String ListarEventos(int caso)
        {
            try {
                return eventoNegocio.ListarEventos(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public String ObtenerEventoPorID(int ID)
        {
            try {
                return eventoNegocio.ObtenerEventoPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}