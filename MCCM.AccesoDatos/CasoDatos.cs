using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class CasoDatos
    {
        public void InsertarCaso(TMCCM_Caso caso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    caso.TB_Eliminado = false;
                    string momentoActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
                    caso.TF_Fecha = Convert.ToDateTime(momentoActual, CultureInfo.InvariantCulture);
                    context.TMCCM_Caso.Add(caso);
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void ActualizarCaso(TMCCM_Caso caso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var result = context.TMCCM_Caso.SingleOrDefault(b => b.TN_ID_Caso == caso.TN_ID_Caso);
                    if (result != null)
                    {
                        result.TC_Area_Trabajo = caso.TC_Area_Trabajo;
                        result.TC_Delito = caso.TC_Delito;
                        result.TC_Descripcion = caso.TC_Descripcion;
                        result.TC_Enfoque_Trabajo = caso.TC_Enfoque_Trabajo;
                        result.TC_Fuente = caso.TC_Fuente;
                        result.TC_Nombre_Caso = caso.TC_Nombre_Caso;
                        result.TN_ECU = caso.TN_ECU;
                        result.TN_Nivel = caso.TN_Nivel;
                        context.Entry(result).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }catch(Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
            
        }

        public void EliminarCaso(int ID)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var result = context.TMCCM_Caso.SingleOrDefault(b => b.TN_ID_Caso == ID);
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

        public string ListarCasos()
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = from casoItem in context.TMCCM_Caso
                                  where casoItem.TB_Eliminado == false
                                  select new
                                  {
                                      TN_ID_Caso = casoItem.TN_ID_Caso,
                                      TC_Nombre_Caso = casoItem.TC_Nombre_Caso,
                                      TC_Delito = casoItem.TC_Delito,
                                      TF_Fecha = casoItem.TF_Fecha
                                  };
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }


        }

        public string ObtenerCasoPorID(int ID)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = (from casoItem in context.TMCCM_Caso
                                   where casoItem.TN_ID_Caso == ID
                                   select new
                                   {
                                       TN_ID_Caso = casoItem.TN_ID_Caso,
                                       TC_Nombre_Caso = casoItem.TC_Nombre_Caso,
                                       TC_Delito = casoItem.TC_Delito,
                                       TF_Fecha = casoItem.TF_Fecha,
                                       TC_Area_Trabajo = casoItem.TC_Area_Trabajo,
                                       TC_Fuente = casoItem.TC_Fuente,
                                       TN_ECU = casoItem.TN_ECU,
                                       TN_Nivel = casoItem.TN_Nivel,
                                       TC_Descripcion = casoItem.TC_Descripcion,
                                       TC_Enfoque_Trabajo = casoItem.TC_Enfoque_Trabajo
                                   }).Single();

                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        //Reporte por meses
        public Dictionary<string, int> ReporteDeEventos(int idCaso, DateTime inicio, DateTime final)
        {
            using (var context = new MCCMEntities())
            {
                Dictionary<string, int> data = new Dictionary<string, int>();

                int diferencia = ((final.Year - inicio.Year) * 12) + final.Month - inicio.Month;
                for (int sumaMes = 0; sumaMes <= diferencia; sumaMes++) 
                {
                    DateTime fecha = inicio.AddMonths(sumaMes);
                    data.Add(fecha.ToString("MM/yy"), context.TMCCM_Evento.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        ((DateTime)e.TF_Fecha).Month == fecha.Month)
                            .ToList()
                            .Count()
                        );
                }

                if (data.Count == 0) return null;
                else return data;
            }
        }

        public Dictionary<string, int> ReporteDeTareas(
            int idCaso, 
            DateTime inicio, 
            DateTime final,
            bool tareasPendientes,
            bool tareasTerminadas)
        {
            using (var context = new MCCMEntities())
            {
                Dictionary<string, int> data = new Dictionary<string, int>();

                if (tareasPendientes) 
                {
                    data.Add("Pendientes", context.TMCCM_Tarea.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        e.TN_Tipo != 3 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (tareasTerminadas)
                {
                    data.Add("Terminadas", context.TMCCM_Tarea.Where(e => 
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        e.TN_Tipo == 3 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (data.Count == 0) return null;
                else return data;
            }
        }

        public Dictionary<string, int> ReporteDeEntidades(
            int idCaso,
            DateTime inicio,
            DateTime final,
            bool persona,
            bool personaJuridica,
            bool vehiculo,
            bool ubicacion,
            bool telefono,
            bool arma,
            bool droga)
        {
            using (var context = new MCCMEntities())
            {
                Dictionary<string, int> data = new Dictionary<string, int>();

                if (persona)
                {
                    data.Add("Persona", context.TMCCM_Entidad_Persona.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (personaJuridica)
                {
                    data.Add("Persona Jurídica", context.TMCCM_Entidad_Persona_Juridica.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (vehiculo)
                {
                    data.Add("Vehículo", context.TMCCM_Entidad_Vehiculo.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (ubicacion)
                {
                    data.Add("Ubicación", context.TMCCM_Entidad_Ubicacion.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (telefono)
                {
                    data.Add("Teléfono", context.TMCCM_Entidad_Telefono.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (arma)
                {
                    data.Add("Arma", context.TMCCM_Entidad_Arma.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (droga)
                {
                    data.Add("Droga", context.TMCCM_Entidad_Droga.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Creacion, final) <= 0)
                            .ToList()
                            .Count
                        );
                }

                if (data.Count == 0) return null;
                else return data;
            }
        }

        public Dictionary<string, float> ReporteDeGastos(
            int idCaso, 
            DateTime inicio, DateTime final,
            bool operativo,
            bool combustible)
        {
            using (var context = new MCCMEntities())
            {
                Dictionary<string, float> data = new Dictionary<string, float>();

                if (operativo)
                {
                    data.Add("Operativo", (float)context.TMCCM_Gasto.Where(e => 
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre == "Operativo" &&
                        DateTime.Compare((DateTime)e.TF_Fecha, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, final) <= 0)
                            .ToList()
                            .Sum(e => e.TD_Monto)
                        );
                }

                if (combustible)
                {
                    data.Add("Combustible", (float)context.TMCCM_Gasto.Where(e => 
                        e.TB_Eliminado == false &&
                        e.TN_ID_Caso == idCaso &&
                        e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre == "Combustible" &&
                        DateTime.Compare((DateTime)e.TF_Fecha, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha, final) <= 0)
                            .ToList()
                            .Sum(e => e.TD_Monto)
                        );
                }

                if (data.Count == 0) return null;
                else return data;
            }
        }

        public Dictionary<string, int> ReporteDeRecursos(
            int idCaso, 
            DateTime inicio, 
            DateTime final,
            bool personal,
            bool vehiculo)
        {
            using (var context = new MCCMEntities())
            {
                Dictionary<string, int> data = new Dictionary<string, int>();

                if (personal)
                {
                    data.Add("Personal", context.TMCCM_Grupo_Usuario.Where(e => 
                        e.TB_Eliminado == false &&
                        e.TMCCM_Grupo.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TMCCM_Grupo.TF_Fecha_Inicio, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TMCCM_Grupo.TF_Fecha_Inicio, final) <= 0)
                            .ToList()
                            .Select(e => e.TMCCM_Usuario.TN_ID_Usuario)
                            .Distinct()
                            .Count()
                        );
                }

                if (vehiculo)
                {
                    data.Add("Vehículos", context.TMCCM_Grupo_Vehiculo.Where(e =>
                        e.TB_Eliminado == false &&
                        e.TMCCM_Grupo.TN_ID_Caso == idCaso &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Hora, inicio) >= 0 &&
                        DateTime.Compare((DateTime)e.TF_Fecha_Hora, final) <= 0)
                            .ToList()
                            .Select(e => e.TMCCM_Vehiculo.TC_Placa)
                            .Distinct()
                            .Count()
                        );
                }

                if (data.Count == 0) return null;
                else return data;
            }
        }
    }
}
