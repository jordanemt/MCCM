using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_VehiculoMarcaDatos
    {
        public string ListarVehiculoMarca()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from vehiculoMarcaItem in context.TMCCM_C_Vehiculo_Marca
                              where vehiculoMarcaItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Marca_Vehiculo = vehiculoMarcaItem.TN_ID_Marca_Vehiculo,
                                  TC_Descripcion = vehiculoMarcaItem.TC_Descripcion
                              };

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarVehiculoMarca(TMCCM_C_Vehiculo_Marca vehiculoMarca)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                vehiculoMarca.TF_Fecha_Creacion = DateTime.Now;
                vehiculoMarca.TB_Eliminado = false;
                context.TMCCM_C_Vehiculo_Marca.Add(vehiculoMarca);
                context.SaveChanges();

            }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }

        }
    }
}
