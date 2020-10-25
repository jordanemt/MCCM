using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_UbicacionCantonDatos
    {
        public List<TMCCM_C_UbicacionCantonDTO> ListarUbicacionCanton(int idProvincia)
        {
            List<TMCCM_C_UbicacionCantonDTO> ubicacionCantones = null;

            using (var context = new MCCMEntities())
            {
                ubicacionCantones = context.TMCCM_C_Ubicacion_Canton.Where(c => c.TB_Eliminado == false && c.TN_ID_Provincia == idProvincia)
                  .Select(ubicacionCantonItem => new TMCCM_C_UbicacionCantonDTO()
                  {
                      TN_ID_Canton = ubicacionCantonItem.TN_ID_Canton,
                      TN_ID_Provincia = ubicacionCantonItem.TN_ID_Provincia,
                      TC_Descripcion = ubicacionCantonItem.TC_Descripcion
                  }).ToList<TMCCM_C_UbicacionCantonDTO>();
            }

            return ubicacionCantones;
        }
    }

}

