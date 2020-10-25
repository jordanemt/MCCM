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
    public class EntidadUbicacionDatos
    {
        Utilidades utilidades = new Utilidades();
        public void InsertarEntidadUbicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            using (var context = new MCCMEntities())
            {
                entidadUbicacion.TB_Eliminado = true;
                context.TMCCM_Entidad_Ubicacion.Add(entidadUbicacion);
                context.SaveChanges();

            }

        }
        public void ActualizarEntidadUbicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Ubicacion.SingleOrDefault(b => b.TN_ID_Ubicacion == entidadUbicacion.TN_ID_Ubicacion);
                if (result != null)
                {
                    result.TN_ID_Caso = entidadUbicacion.TN_ID_Caso;
                    result.TN_ID_Tipo_Ubicacion = entidadUbicacion.TN_ID_Tipo_Ubicacion;
                    result.TN_ID_Provincia = entidadUbicacion.TN_ID_Provincia;
                    result.TN_ID_Canton = entidadUbicacion.TN_ID_Canton;
                    result.TN_ID_Distrito = entidadUbicacion.TN_ID_Distrito;
                    result.TC_Sennas = entidadUbicacion.TC_Sennas;
                    result.TD_Latitud = entidadUbicacion.TD_Latitud;
                    result.TD_Longitud = entidadUbicacion.TD_Longitud;
                    result.TF_Fecha_Creacion = entidadUbicacion.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadUbicacion.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadUbicacion.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadUbicacion.TC_Modificado_Por;
                    result.TB_Verificado = entidadUbicacion.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }


        }

        public void EliminarEntidadUbicacion(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Ubicacion.SingleOrDefault(b => b.TN_ID_Ubicacion == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadUbicacionDTO> ListarEntidadUbicacion(int caso)
        {
            List<TMCCM_EntidadUbicacionDTO> entidadUbicacionDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadUbicacionDTO = context.TMCCM_Entidad_Ubicacion.Where(c => c.TB_Eliminado == false && c.TN_ID_Caso == caso)
                  .Select(ubicacionItem => new TMCCM_EntidadUbicacionDTO()
                  {
                   TN_ID_Ubicacion = ubicacionItem.TN_ID_Ubicacion,
                   TN_ID_Caso = ubicacionItem.TN_ID_Caso,
                   TN_ID_Tipo_Ubicacion = ubicacionItem.TN_ID_Tipo_Ubicacion,
                   TN_ID_Provincia = ubicacionItem.TN_ID_Provincia,
                   TN_ID_Canton = ubicacionItem.TN_ID_Canton,
                   TN_ID_Distrito = ubicacionItem.TN_ID_Distrito,
                   TC_Sennas = ubicacionItem.TC_Sennas,
                   TD_Latitud = ubicacionItem.TD_Latitud,
                   TD_Longitud = ubicacionItem.TD_Longitud,
                   TF_Fecha_Creacion = ubicacionItem.TF_Fecha_Creacion,
                   TF_Fecha_Modificacion = ubicacionItem.TF_Fecha_Modificacion,
                   TC_Creado_Por = ubicacionItem.TC_Creado_Por,
                   TC_Modificado_Por = ubicacionItem.TC_Modificado_Por,
                   TB_Verificado = ubicacionItem.TB_Verificado

                  }).ToList<TMCCM_EntidadUbicacionDTO>();
            }

            return entidadUbicacionDTO;
        }


        public TMCCM_EntidadUbicacionDTO ObtenerEntidadUbicacionPorID(int ID)
        {
            TMCCM_EntidadUbicacionDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from ubicacionItem in context.TMCCM_Entidad_Ubicacion
                       select new TMCCM_EntidadUbicacionDTO()
                       {
                           TN_ID_Ubicacion = ubicacionItem.TN_ID_Ubicacion,
                           TN_ID_Caso = ubicacionItem.TN_ID_Caso,
                           TN_ID_Tipo_Ubicacion = ubicacionItem.TN_ID_Tipo_Ubicacion,
                           TN_ID_Provincia = ubicacionItem.TN_ID_Provincia,
                           TN_ID_Canton = ubicacionItem.TN_ID_Canton,
                           TN_ID_Distrito = ubicacionItem.TN_ID_Distrito,
                           TC_Sennas = ubicacionItem.TC_Sennas,
                           TD_Latitud = ubicacionItem.TD_Latitud,
                           TD_Longitud = ubicacionItem.TD_Longitud,
                           TF_Fecha_Creacion = ubicacionItem.TF_Fecha_Creacion,
                           TF_Fecha_Modificacion = ubicacionItem.TF_Fecha_Modificacion,
                           TC_Creado_Por = ubicacionItem.TC_Creado_Por,
                           TC_Modificado_Por = ubicacionItem.TC_Modificado_Por,
                           TB_Verificado = ubicacionItem.TB_Verificado
                       }).Where(x => x.TN_ID_Ubicacion == ID).Single();
            }
            return aux;
        }

    }
    }


