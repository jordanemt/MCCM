using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_UbicacionDistritoDatos
    {
        public List<TMCCM_C_UbicacionDistritoDTO> ListarUbicacionDistrito(int idCanton)
        {
            List<TMCCM_C_UbicacionDistritoDTO> ubicacionDistritos = null;

            using (var context = new MCCMEntities())
            {
                ubicacionDistritos = context.TMCCM_C_Ubicacion_Distrito.Where(c => c.TB_Eliminado == false && c.TN_ID_Canton == idCanton)
                  .Select(ubicacionDistritoItem => new TMCCM_C_UbicacionDistritoDTO()
                  {
                      TN_ID_Distrito= ubicacionDistritoItem.TN_ID_Distrito,
                      TN_ID_Canton = ubicacionDistritoItem.TN_ID_Canton,
                      TF_Fecha_Creacion = ubicacionDistritoItem.TF_Fecha_Creacion,
                      TC_Descripcion = ubicacionDistritoItem.TC_Descripcion,
                      TB_Eliminado = ubicacionDistritoItem.TB_Eliminado
                  }).ToList<TMCCM_C_UbicacionDistritoDTO>();
            }

            return ubicacionDistritos;
        }

        public TMCCM_C_Ubicacion_Distrito ObtenerUbicacionDistritoPorID(int ID)
        {
            TMCCM_C_Ubicacion_Distrito aux;
            using (var context = new MCCMEntities())
            {
                aux = (from ubicacionDistritoItem in context.TMCCM_C_Ubicacion_Distrito
                       select new TMCCM_C_Ubicacion_Distrito()
                       {
                           TN_ID_Distrito = ubicacionDistritoItem.TN_ID_Distrito,
                           TN_ID_Canton = ubicacionDistritoItem.TN_ID_Canton,
                           TF_Fecha_Creacion = ubicacionDistritoItem.TF_Fecha_Creacion,
                           TC_Descripcion = ubicacionDistritoItem.TC_Descripcion,
                           TB_Eliminado = ubicacionDistritoItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Distrito == ID).Single();
            }
            return aux;
        }
    }

}

