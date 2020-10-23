using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_TipoUbicacionDatos
    {
        public List<TMCCM_C_TipoUbicacionDTO> ListaTipoUbicacion()
        {
            List<TMCCM_C_TipoUbicacionDTO> ubicacion_Tipos = null;

            using (var context = new MCCMEntities())
            {
                ubicacion_Tipos = context.TMCCM_C_Ubicacion_Tipo_Ubicacion.Where(c => c.TB_Eliminado == false)
                  .Select(ubicacionTipoItem => new TMCCM_C_TipoUbicacionDTO()
                  {
                      TN_ID_Tipo_Ubicacion= ubicacionTipoItem.TN_ID_Tipo_Ubicacion,
                      TC_Nombre = ubicacionTipoItem.TC_Nombre,
                      TC_Descripcion = ubicacionTipoItem.TC_Descripcion,
                      TB_Eliminado = ubicacionTipoItem.TB_Eliminado

                  }).ToList<TMCCM_C_TipoUbicacionDTO>();
            }

            return ubicacion_Tipos;
        }
        public TMCCM_C_Ubicacion_Tipo_Ubicacion ObtenerTipoUbicacionPorID(int ID)
        {
            TMCCM_C_Ubicacion_Tipo_Ubicacion aux;
            using (var context = new MCCMEntities())
            {
                aux = (from ubicacionTipoItem in context.TMCCM_C_Ubicacion_Tipo_Ubicacion
                       select new TMCCM_C_Ubicacion_Tipo_Ubicacion()
                       {
                           TN_ID_Tipo_Ubicacion = ubicacionTipoItem.TN_ID_Tipo_Ubicacion,
                           TC_Nombre = ubicacionTipoItem.TC_Nombre,
                           TC_Descripcion = ubicacionTipoItem.TC_Descripcion,
                           TB_Eliminado = ubicacionTipoItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Tipo_Ubicacion == ID).Single();
            }
            return aux;
        }

    }
}
