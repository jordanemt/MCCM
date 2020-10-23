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
                      TF_Fecha_Creacion = ubicacionCantonItem.TF_Fecha_Creacion,
                      TC_Descripcion = ubicacionCantonItem.TC_Descripcion,
                      TB_Eliminado = ubicacionCantonItem.TB_Eliminado
                  }).ToList<TMCCM_C_UbicacionCantonDTO>();
            }

            return ubicacionCantones;
        }

        public TMCCM_C_Ubicacion_Canton ObtenerUbicacionCantonPorID(int ID)
        {
            TMCCM_C_Ubicacion_Canton aux;
            using (var context = new MCCMEntities())
            {
                aux = (from ubicacionCantonItem in context.TMCCM_C_Ubicacion_Canton
                       select new TMCCM_C_Ubicacion_Canton()
                       {
                           TN_ID_Canton = ubicacionCantonItem.TN_ID_Canton,
                           TN_ID_Provincia = ubicacionCantonItem.TN_ID_Provincia,
                           TF_Fecha_Creacion = ubicacionCantonItem.TF_Fecha_Creacion,
                           TC_Descripcion = ubicacionCantonItem.TC_Descripcion,
                           TB_Eliminado = ubicacionCantonItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Canton == ID).Single();
            }
            return aux;
        }
    }

}

