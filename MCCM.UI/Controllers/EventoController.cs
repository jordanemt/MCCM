﻿using MCCM.Entidad;
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
            evento.TN_ID_Caso = caso;
            eventoNegocio.InsertarEvento(evento);
            return "S";
        }

        [HttpPost]
        public String EliminarEventoPorID(int eventoID) {
            return eventoNegocio.EliminarEvento(eventoID);
        }

        [HttpGet]
        public String ListarEventos(int caso)
        {
            return JsonConvert.SerializeObject(eventoNegocio.ListarEventos(caso), Formatting.Indented);
        }

    }
}