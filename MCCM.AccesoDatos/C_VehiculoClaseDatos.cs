using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
   public class C_VehiculoClaseDatos
    {
        public List<TMCCM_C_VehiculoClaseDTO> ListarVehiculoClase()
        {
            List<TMCCM_C_VehiculoClaseDTO> vehiculoClases = null;

            using (var context = new MCCMEntities())
            {
                vehiculoClases = context.TMCCM_C_Vehiculo_Clase.Where(c => c.TB_Eliminado == false)
                  .Select(vehiculoClaseItem => new TMCCM_C_VehiculoClaseDTO()
                  {
                      TN_ID_Clase_Vehiculo = vehiculoClaseItem.TN_ID_Clase_Vehiculo,
                      TC_Descripcion = vehiculoClaseItem.TC_Descripcion
                  }).ToList<TMCCM_C_VehiculoClaseDTO>();
            }

            return vehiculoClases;
        }
    }
}
