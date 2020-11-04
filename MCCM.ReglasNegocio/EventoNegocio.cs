﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.AccesoDatos;
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
        public string ListarEventos(int caso)
        {
            return eventoDatos.ListarEventos(caso);
        }

        public string ObtenerEventoPorID(int ID)
        {
            return eventoDatos.ObtenerEventoPorID(ID);
        }


    }
}
