using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class EntidadDrogaDatos
    {
        
        public void InsertarEntidadDroga(TMCCM_Entidad_Droga entidadDroga)
        {
            using (var context = new MCCMEntities())
            {
                entidadDroga.TB_Eliminado = false;
                entidadDroga.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_Entidad_Droga.Add(entidadDroga);
                context.SaveChanges();

            }

        }
        public void ActualizarEntidadDroga(TMCCM_Entidad_Droga entidadDroga)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Droga.SingleOrDefault(b => b.TN_ID_Droga == entidadDroga.TN_ID_Droga);
                if (result != null)
                {
                    result.TN_ID_Droga = entidadDroga.TN_ID_Droga;
                    result.TN_ID_Tipo_Droga = entidadDroga.TN_ID_Tipo_Droga;
                    result.TC_Nombre = entidadDroga.TC_Nombre;
                    result.TC_Detalle = entidadDroga.TC_Detalle;
                    result.TN_Cantidad = entidadDroga.TN_Cantidad;
                    result.TF_Fecha_Decomiso = entidadDroga.TF_Fecha_Decomiso;
                    result.TF_Fecha_Creacion = entidadDroga.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = DateTime.Now; 
                    result.TC_Creado_Por = entidadDroga.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadDroga.TC_Modificado_Por;
                    result.TB_Verificado = entidadDroga.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }

        }

        public void EliminarEntidadDroga(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Droga.SingleOrDefault(b => b.TN_ID_Droga == ID);
                if (result != null)
                {
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public string ListarEntidadDroga(int caso)
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from drogaItem in context.TMCCM_Entidad_Droga
                              where drogaItem.TB_Eliminado == false
                              where drogaItem.TN_ID_Caso == caso
                              select new
                              {
                                  TN_ID_Droga = drogaItem.TN_ID_Droga,
                                  TN_ID_Caso = drogaItem.TN_ID_Caso,
                                  TN_ID_Tipo_Droga = drogaItem.TN_ID_Tipo_Droga,
                                  TC_Nombre = drogaItem.TC_Nombre,
                                  TN_Cantidad = drogaItem.TN_Cantidad
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented); 
            }

        }
        public string ObtenerEntidadDrogaPorID(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from drogaItem in context.TMCCM_Entidad_Droga
                               where drogaItem.TB_Eliminado == false
                               where drogaItem.TN_ID_Droga == ID
                               select new
                               {
                                   TN_ID_Droga = drogaItem.TN_ID_Droga,
                                   TN_ID_Caso = drogaItem.TN_ID_Caso,
                                   TN_ID_Tipo_Droga = drogaItem.TN_ID_Tipo_Droga,
                                   TC_Nombre = drogaItem.TC_Nombre,
                                   TC_Detalle = drogaItem.TC_Detalle,
                                   TN_Cantidad = drogaItem.TN_Cantidad,
                                   TF_Fecha_Decomiso = drogaItem.TF_Fecha_Decomiso,
                                   TF_Fecha_Creacion = drogaItem.TF_Fecha_Creacion,
                                   TF_Fecha_Modificacion = drogaItem.TF_Fecha_Modificacion,
                                   TC_Creado_Por = drogaItem.TC_Creado_Por,
                                   TC_Modificado_Por = drogaItem.TC_Modificado_Por,
                                   TB_Verificado = drogaItem.TB_Verificado
                               }).Single();

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

    }
}
