using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_UbicacionProvinciaDatos
    {
        public List<TMCCM_C_UbicacionProvinciaDTO> ListarUbicacionProvincia()
        {
            List<TMCCM_C_UbicacionProvinciaDTO> ubicacionProvincias = null;

            using (var context = new MCCMEntities())
            {
                ubicacionProvincias = context.TMCCM_C_Ubicacion_Provincia.Where(c => c.TB_Eliminado == false)
                  .Select(ubicacionProvinciaItem => new TMCCM_C_UbicacionProvinciaDTO()
                  {
                      TN_ID_Provincia = ubicacionProvinciaItem.TN_ID_Provincia,
                      TC_Descripcion = ubicacionProvinciaItem.TC_Descripcion,
                  }).ToList<TMCCM_C_UbicacionProvinciaDTO>();
            }

            return ubicacionProvincias;
        }
    }

}

