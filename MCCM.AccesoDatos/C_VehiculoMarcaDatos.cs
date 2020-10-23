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
                      TF_Fecha_Creacion = vehiculoMarcaItem.TF_Fecha_Creacion,
                      TC_Descripcion = vehiculoMarcaItem.TC_Descripcion,
                      TB_Eliminado = vehiculoMarcaItem.TB_Eliminado
                  }).ToList<TMCCM_C_VehiculoMarcaDTO>();
            }

            return vehiculoMarcas;
        }

        public TMCCM_C_Vehiculo_Marca ObtenerVehiculoMarcaPorID(int ID)
        {
            TMCCM_C_Vehiculo_Marca aux;
            using (var context = new MCCMEntities())
            {
                aux = (from vehiculoMarcaItem in context.TMCCM_C_Vehiculo_Marca
                       select new TMCCM_C_Vehiculo_Marca()
                       {
                           TN_ID_Marca_Vehiculo = vehiculoMarcaItem.TN_ID_Marca_Vehiculo,
                           TF_Fecha_Creacion = vehiculoMarcaItem.TF_Fecha_Creacion,
                           TC_Descripcion = vehiculoMarcaItem.TC_Descripcion,
                           TB_Eliminado = vehiculoMarcaItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Marca_Vehiculo == ID).Single();
            }
            return aux;
        }
    }
}
