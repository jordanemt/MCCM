using System;
using System.Collections.Generic;
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
        public List<TMCCM_EventoDTO> ListarEventos()
        {
            return eventoDatos.ListarEventos();
        }

        public TMCCM_EventoDTO ObtenerEventoPorID(int ID)
        {
            return eventoDatos.ObtenerEventoPorID(ID);
        }


    }
}
