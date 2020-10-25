using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public  class C_VehiculoMarcaDatos
    {
        public List<TMCCM_C_VehiculoMarcaDTO> ListarVehiculoMarca()
        {
            List<TMCCM_C_VehiculoMarcaDTO> vehiculoMarcas = null;

            using (var context = new MCCMEntities())
            {
                vehiculoMarcas = context.TMCCM_C_Vehiculo_Marca.Where(c => c.TB_Eliminado == false)
                  .Select(vehiculoMarcaItem => new TMCCM_C_VehiculoMarcaDTO()
                  {
                      TN_ID_Marca_Vehiculo = vehiculoMarcaItem.TN_ID_Marca_Vehiculo,
                      TC_Descripcion = vehiculoMarcaItem.TC_Descripcion
                  }).ToList<TMCCM_C_VehiculoMarcaDTO>();
            }

            return vehiculoMarcas;
        }
    }
}
