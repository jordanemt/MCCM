using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using Newtonsoft.Json;

namespace MCCM.AccesoDatos
{
    public class EventoDatos
    {
        public void InsertarEvento(TMCCM_Evento evento)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    evento.TB_Eliminado = false;
                    context.TMCCM_Evento.Add(evento);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void ActualizarEvento(TMCCM_Evento evento)
        {
            try
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
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void EliminarEvento(int ID)
        {
            try
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
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public string ListarEventos(int caso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = from eventoItem in context.TMCCM_Evento
                                  where eventoItem.TB_Eliminado == false
                                  where eventoItem.TN_ID_Caso == caso
                                  select new
                                  {
                                      TN_ID_Evento = eventoItem.TN_ID_Evento,
                                      TC_Novedad = eventoItem.TC_Novedad,
                                      TC_Lugar = eventoItem.TC_Lugar,
                                      TC_Informa = eventoItem.TC_Informa,
                                      TF_Fecha = eventoItem.TF_Fecha
                                  };
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }

        }

        public string ObtenerEventoPorID(int ID)
        {
            try
            {
                using (var context = new MCCMEntities())
                {

                    var anonimo = (from eventoItem in context.TMCCM_Evento
                                   where eventoItem.TN_ID_Evento == ID
                                   select new
                                   {
                                       TN_ID_Evento = eventoItem.TN_ID_Evento,
                                       TC_Novedad = eventoItem.TC_Novedad,
                                       TC_Lugar = eventoItem.TC_Lugar,
                                       TC_Informa = eventoItem.TC_Informa,
                                       TF_Fecha = eventoItem.TF_Fecha
                                   }).Single();
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }
    }
}
