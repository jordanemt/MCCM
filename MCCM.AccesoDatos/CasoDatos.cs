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
            using (var context = new MCCMEntities())
            {
                caso.TB_Eliminado = false;
                string momentoActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
                caso.TF_Fecha = Convert.ToDateTime(momentoActual, CultureInfo.InvariantCulture);
                context.TMCCM_Caso.Add(caso);
                context.SaveChanges();

            }
        }

        public void ActualizarCaso(TMCCM_Caso caso)
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
        }

        public void EliminarCaso(int ID)
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

        public string ListarCasos()
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

        public string ObtenerCasoPorID(int ID)
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

        public int ReporteDeEventos(int idCaso, DateTime inicio, DateTime final)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Evento.Where(e => e.TB_Eliminado == false &&
                    e.TN_ID_Caso == idCaso).ToList().Count();
            }
        }

        public List<int> ReporteDeTareas(int idCaso, DateTime inicio, DateTime final)
        {
            using (var context = new MCCMEntities())
            {
                List<int> data = new List<int>();

                data.Add(context.TMCCM_Tarea.Where(e => e.TB_Eliminado == false && 
                    e.TN_ID_Caso == idCaso &&
                    e.TN_Tipo != 3).ToList().Count);
                data.Add(context.TMCCM_Tarea.Where(e => e.TB_Eliminado == false &&
                    e.TN_ID_Caso == idCaso &&
                    e.TN_Tipo == 3).ToList().Count);

                return data;
            }
        }

        public List<int> ReporteDeEntidades(int idCaso, DateTime inicio, DateTime final) {
            using (var context = new MCCMEntities())
            {
                List<int> data = new List<int>();

                data.Add(context.TMCCM_Entidad_Persona.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Persona_Juridica.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Vehiculo.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Ubicacion.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Telefono.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Arma.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);
                data.Add(context.TMCCM_Entidad_Droga.Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso).ToList().Count);

                return data;
            }
        }

        public List<float> ReporteDeGastos(int idCaso, DateTime inicio, DateTime final)
        {
            using (var context = new MCCMEntities())
            {
                List<float> data = new List<float>();

                data.Add((float)context.TMCCM_Gasto.Where(e => e.TB_Eliminado == false &&
                    e.TN_ID_Caso == idCaso &&
                    e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre == "Operativo").ToList().Sum(e => e.TD_Monto));
                data.Add((float)context.TMCCM_Gasto.Where(e => e.TB_Eliminado == false &&
                    e.TN_ID_Caso == idCaso &&
                    e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre == "Combustible").ToList().Sum(e => e.TD_Monto));
                data.Add((float)context.TMCCM_Gasto.Where(e => e.TB_Eliminado == false &&
                    e.TN_ID_Caso == idCaso &&
                    (e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre != "Operativo" &&
                    e.TMCCM_C_Gasto_Tipo_Gasto.TC_Nombre != "Combustible")).ToList().Sum(e => e.TD_Monto));

                return data;
            }
        }

        public List<int> ReporteDeRecursos(int idCaso, DateTime inicio, DateTime final)
        {
            using (var context = new MCCMEntities())
            {
                List<int> data = new List<int>();

                data.Add(context.TMCCM_Grupo_Usuario.Where(e => e.TB_Eliminado == false &&
                    e.TMCCM_Grupo.TN_ID_Caso == idCaso).ToList().Count());
                data.Add(context.TMCCM_Grupo_Vehiculo.Where(e => e.TB_Eliminado == false &&
                    e.TMCCM_Grupo.TN_ID_Caso == idCaso).ToList().Count());

                return data;
            }
        }
    }
}
