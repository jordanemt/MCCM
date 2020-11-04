using MCCM.Entidad;
using MCCM.Entidad.DTO;
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
    }



}
