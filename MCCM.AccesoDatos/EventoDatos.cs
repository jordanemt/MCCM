using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;

namespace MCCM.AccesoDatos
{
    public class EventoDatos
    {
        public void InsertarEvento(TMCCM_Evento evento)
        {
            using (var context = new MCCMEntities())
            {
                evento.TB_Eliminado = true;
                context.TMCCM_Evento.Add(evento);
                context.SaveChanges();
            }
        }

        public void ActualizarEvento(TMCCM_Evento evento)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Evento.SingleOrDefault(b => b.TN_ID_Evento == evento.TN_ID_Evento);
                if (result != null)
                {
                    result.TN_ID_Evento = evento.TN_ID_Evento;
                    result.TC_Informa = evento.TC_Informa;
                    result.TC_Lugar = evento.TC_Lugar;
                    result.TC_Novedad = evento.TC_Novedad;
                    result.TF_Fecha = evento.TF_Fecha;
                    result.TF_Hora = evento.TF_Hora;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEvento(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Evento.SingleOrDefault(b => b.TN_ID_Evento == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }




        public List<TMCCM_EventoDTO> ListarEventos()
        {
            List<TMCCM_EventoDTO> eventosDTO = null;

            using (var context = new MCCMEntities())
            {
                eventosDTO = context.TMCCM_Evento.Where(c => c.TB_Eliminado == true)
                  .Select(evento => new TMCCM_EventoDTO()
                  {
                      TN_ID_Evento = evento.TN_ID_Evento,
                      TC_Informa = evento.TC_Informa,
                      TC_Lugar = evento.TC_Lugar,
                      TC_Novedad = evento.TC_Novedad,
                      TF_Fecha = evento.TF_Fecha,
                      TF_Hora = evento.TF_Hora
                  }).ToList<TMCCM_EventoDTO>();

                return eventosDTO;
            }
        }

        public TMCCM_EventoDTO ObtenerEventoPorID(int ID)
        {
            TMCCM_EventoDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from evento in context.TMCCM_Evento
                       select new TMCCM_EventoDTO()
                       {
                           TN_ID_Evento = evento.TN_ID_Evento,
                           TC_Informa = evento.TC_Informa,
                           TC_Lugar = evento.TC_Lugar,
                           TC_Novedad = evento.TC_Novedad,
                           TF_Fecha = evento.TF_Fecha,
                           TF_Hora = evento.TF_Hora
                       }).Where(x => x.TN_ID_Evento == ID).Single();
            }
            return aux;
        }
    }
}
