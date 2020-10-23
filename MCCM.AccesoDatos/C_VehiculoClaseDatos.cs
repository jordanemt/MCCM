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
                      TF_Fecha_Creacion = vehiculoClaseItem.TF_Fecha_Creacion,
                      TC_Descripcion = vehiculoClaseItem.TC_Descripcion,
                      TB_Eliminado = vehiculoClaseItem.TB_Eliminado
                  }).ToList<TMCCM_C_VehiculoClaseDTO>();
            }

            return vehiculoClases;
        }

        public TMCCM_C_Vehiculo_Clase ObtenerVehiculoClasePorID(int ID)
        {
            TMCCM_C_Vehiculo_Clase aux;
            using (var context = new MCCMEntities())
            {
                aux = (from vehiculoClaseItem in context.TMCCM_C_Vehiculo_Clase
                       select new TMCCM_C_Vehiculo_Clase()
                       {
                           TN_ID_Clase_Vehiculo = vehiculoClaseItem.TN_ID_Clase_Vehiculo,
                           TF_Fecha_Creacion = vehiculoClaseItem.TF_Fecha_Creacion,
                           TC_Descripcion = vehiculoClaseItem.TC_Descripcion,
                           TB_Eliminado = vehiculoClaseItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Clase_Vehiculo == ID).Single();
            }
            return aux;
        }
    }
}
