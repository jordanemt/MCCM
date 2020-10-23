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
                      TF_Fecha_Creacion = ubicacionProvinciaItem.TF_Fecha_Creacion,
                      TC_Descripcion = ubicacionProvinciaItem.TC_Descripcion,
                      TB_Eliminado = ubicacionProvinciaItem.TB_Eliminado
                  }).ToList<TMCCM_C_UbicacionProvinciaDTO>();
            }

            return ubicacionProvincias;
        }

        public TMCCM_C_Ubicacion_Provincia ObtenerUbicacionProvinciaPorID(int ID)
        {
            TMCCM_C_Ubicacion_Provincia aux;
            using (var context = new MCCMEntities())
            {
                aux = (from ubicacionProvinciaItem in context.TMCCM_C_Ubicacion_Provincia
                       select new TMCCM_C_Ubicacion_Provincia()
                       {
                           TN_ID_Provincia = ubicacionProvinciaItem.TN_ID_Provincia,
                           TF_Fecha_Creacion = ubicacionProvinciaItem.TF_Fecha_Creacion,
                           TC_Descripcion = ubicacionProvinciaItem.TC_Descripcion,
                           TB_Eliminado = ubicacionProvinciaItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Provincia == ID).Single();
            }
            return aux;
        }
    }

}

