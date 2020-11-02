using MCCM.Entidad;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class TareaDatos
    {
        public void InsertarTarea(TMCCM_Tarea tarea)
        {
            using (var context = new MCCMEntities())
            {
                tarea.TB_Eliminado = false;
                context.TMCCM_Tarea.Add(tarea);
                context.SaveChanges();
            }
        }

        public void ModificarTarea(TMCCM_Tarea tarea)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Tarea.SingleOrDefault(b => b.TN_ID_Tarea == tarea.TN_ID_Tarea);
                if (result != null)
                {
                    result.TN_ID_Tarea = tarea.TN_ID_Tarea;
                    result.TN_ID_Usuario = tarea.TN_ID_Usuario;
                    result.TF_Fecha = tarea.TF_Fecha;
                    result.TC_Diligencia = tarea.TC_Diligencia;
                    result.TC_Lugar = tarea.TC_Lugar;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarTarea(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Tarea.SingleOrDefault(b => b.TN_ID_Tarea == ID);
                if (result != null)
                {
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public string ListarTareas(int idCaso)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from t in context.TMCCM_Tarea
                              from u in context.TMCCM_Usuario
                              where t.TB_Eliminado == false
                              where t.TN_ID_Caso == idCaso
                              where t.TN_ID_Usuario==u.TN_ID_Usuario
                              select new
                              {
                                  TN_ID_Tarea = t.TN_ID_Tarea,
                                  TC_Diligencia = t.TC_Diligencia,
                                  TC_Lugar= t.TC_Lugar,
                                  T_Usuario = u.TC_Identificacion +" "+ u.TC_Nombre +" "+u.TC_Primer_Apellido+" "+u.TC_Segundo_Apellido,
                                  TF_Fecha = t.TF_Fecha
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }

        }

        public string ObtenerTareaPorID(int ID)
        {
            
            using (var context = new MCCMEntities())
            {
                var anonimo = from t in context.TMCCM_Tarea
                              where t.TB_Eliminado == false
                              where t.TN_ID_Tarea==ID
                              select new
                              {
                                  TN_ID_Tarea = t.TN_ID_Tarea,
                                  TC_Diligencia = t.TC_Diligencia,
                                  TN_ID_Usuario = t.TN_ID_Usuario,
                                  TC_Lugar = t.TC_Lugar,
                                  TF_Fecha = t.TF_Fecha
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);   
            }
        }

        public string ObtenerCatalogoUsuarios() {
            using (var context = new MCCMEntities()) {
                var anonimo = from u in context.TMCCM_Usuario
                              where u.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Tarea = u.TN_ID_Usuario,
                                  TC_Identificacion = u.TC_Identificacion,
                                  TC_Nombre_Completo = u.TC_Nombre + " " + u.TC_Primer_Apellido + " " + u.TC_Segundo_Apellido
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

    }
}
