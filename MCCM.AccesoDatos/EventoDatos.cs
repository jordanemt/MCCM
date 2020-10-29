using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
                evento.TB_Eliminado = false;
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
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }




        public List<sp_obtenerEventosPorCaso_Result> ListarEventos(int caso)
        {

            using (var context = new MCCMEntities())
            {
                var result= context.sp_obtenerEventosPorCaso(caso).ToList();
                return result;
                
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
                       }).Where(x => x.TN_ID_Evento == ID).Single();
            }
            return aux;
        }
    }
}
