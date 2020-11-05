using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_TipoUbicacionDatos
    {
        public string ListarTipoUbicacion()
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from ubicacionTipoItem in context.TMCCM_C_Ubicacion_Tipo_Ubicacion
                              where ubicacionTipoItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Tipo_Ubicacion = ubicacionTipoItem.TN_ID_Tipo_Ubicacion,
                                  TC_Nombre = ubicacionTipoItem.TC_Nombre,
                                  TC_Descripcion = ubicacionTipoItem.TC_Descripcion
                              };

               return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarTipoUbicacion(TMCCM_C_Ubicacion_Tipo_Ubicacion tipoUbicacion)
        {
            using (var context = new MCCMEntities())
            {
                tipoUbicacion.TB_Eliminado = false;
                context.TMCCM_C_Ubicacion_Tipo_Ubicacion.Add(tipoUbicacion);
                context.SaveChanges();

            }

        }

    }
}
