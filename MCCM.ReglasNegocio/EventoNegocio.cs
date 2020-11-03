﻿using System.Collections.Generic;
using MCCM.Entidad;
using MCCM.Entidad.DTO;

namespace MCCM.ReglasNegocio
{
    public class EventoNegocio
    {

        AccesoDatos.EventoDatos eventoDatos = new AccesoDatos.EventoDatos();

        public void InsertarEvento(TMCCM_Evento evento)
        {
            eventoDatos.InsertarEvento(evento);
        }

        public void ActualizarEvento(TMCCM_Evento evento)
        {
            eventoDatos.ActualizarEvento(evento);
        }

        public string EliminarEvento(int ID)
        {
            eventoDatos.EliminarEvento(ID);
            return "S";
        }
        public List<sp_obtenerEventosPorCaso_Result> ListarEventos(int caso)
        {
            return eventoDatos.ListarEventos(caso);
        }

        public TMCCM_EventoDTO ObtenerEventoPorID(int ID)
        {
            return eventoDatos.ObtenerEventoPorID(ID);
        }


    }
}
