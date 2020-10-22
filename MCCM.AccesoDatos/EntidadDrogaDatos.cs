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
    public class EntidadDrogaDatos
    {
        
        public void InsertarEntidadDroga(TMCCM_Entidad_Droga entidadDroga)
        {
            using (var context = new MCCMEntities())
            {
                entidadDroga.TB_Eliminado = true;
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
                    result.TN_ID_Caso = entidadDroga.TN_ID_Caso;
                    result.TN_ID_Tipo_Droga = entidadDroga.TN_ID_Tipo_Droga;
                    result.TC_Nombre = entidadDroga.TC_Nombre;
                    result.TC_Detalle = entidadDroga.TC_Detalle;
                    result.TN_Cantidad = entidadDroga.TN_Cantidad;
                    result.TF_Fecha_Decomiso = entidadDroga.TF_Fecha_Decomiso;
                    result.TF_Fecha_Creacion = entidadDroga.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadDroga.TF_Fecha_Modificacion;
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
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadDrogaDTO> ListarEntidadDroga(int caso)
        {
            List<TMCCM_EntidadDrogaDTO> entidadDrogaDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadDrogaDTO = context.TMCCM_Entidad_Droga.Where(c => c.TB_Eliminado==true && c.TN_ID_Caso == caso)
                  .Select(drogaItem => new TMCCM_EntidadDrogaDTO()
                  {
                    TN_ID_Droga= drogaItem.TN_ID_Droga,
                    TN_ID_Caso = drogaItem.TN_ID_Caso,
                    TN_ID_Tipo_Droga = drogaItem.TN_ID_Tipo_Droga,
                    TC_Nombre = drogaItem.TC_Nombre,
                    TN_Cantidad = drogaItem.TN_Cantidad,

            }).ToList<TMCCM_EntidadDrogaDTO>();
            }
            return entidadDrogaDTO;
        }


        public TMCCM_EntidadDrogaDTO ObtenerEntidadDrogaPorID(int ID)
        {
            TMCCM_EntidadDrogaDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from drogaItem in context.TMCCM_Entidad_Droga
                       select new TMCCM_EntidadDrogaDTO()
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
                       }).Where(x => x.TN_ID_Droga == ID).Single();
            }
            return aux;
        }

    }
}
