using MCCM.Entidad;
using MCCM.Entidad.DTO;
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

        public void ActualizarTarea(TMCCM_Tarea tarea)
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
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TareaCasoResult> ListarTareas(int idCaso)
        {
            using (var context = new MCCMEntities())
            {
                return context.sp_obtenerTareaPorCaso(idCaso).ToList();
            }

        }

        public TMCCM_TareaDTO ObtenerTareaPorID(int ID)
        {
            TMCCM_TareaDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from tareaItem in context.TMCCM_Tarea
                       select new TMCCM_TareaDTO()
                       {
                           TN_ID_Tarea = tareaItem.TN_ID_Tarea,
                           TN_ID_Usuario = tareaItem.TN_ID_Usuario,
                           TF_Fecha = tareaItem.TF_Fecha,
                           TC_Diligencia = tareaItem.TC_Diligencia,
                           TC_Lugar = tareaItem.TC_Lugar
                       }).Where(x => x.TN_ID_Tarea == ID).Single();
            }
            return aux;
        }

        public List<CatalogoUsuarioResult> ObtenerCatalogoUsuarios() {
            using (var context = new MCCMEntities()) {
                return context.sp_Obtener_Catalogo_Usuario().ToList();
            }
        }

    }
}
