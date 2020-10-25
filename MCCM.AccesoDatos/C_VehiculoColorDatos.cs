using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_VehiculoColorDatos
    {
        public List<TMCCM_C_VehiculoColorDTO> ListarVehiculoColor()
        {
            List<TMCCM_C_VehiculoColorDTO> vehiculoColor = null;

            using (var context = new MCCMEntities())
            {
                vehiculoColor = context.TMCCM_C_Vehiculo_Color.Where(c => c.TB_Eliminado == false)
                  .Select(vehiculoColorItem => new TMCCM_C_VehiculoColorDTO()
                  {
                      TN_ID_Color_Vehiculo = vehiculoColorItem.TN_ID_Color_Vehiculo,
                      TC_Descripcion = vehiculoColorItem.TC_Descripcion
                  }).ToList<TMCCM_C_VehiculoColorDTO>();
            }

            return vehiculoColor;
        }
    }
}
