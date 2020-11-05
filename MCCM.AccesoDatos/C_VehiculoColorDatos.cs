using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_VehiculoColorDatos
    {
        public string ListarVehiculoColor()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from vehiculoColorItem in context.TMCCM_C_Vehiculo_Color
                              where vehiculoColorItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Color_Vehiculo = vehiculoColorItem.TN_ID_Color_Vehiculo,
                                  TC_Descripcion = vehiculoColorItem.TC_Descripcion
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarVehiculoColor(TMCCM_C_Vehiculo_Color vehiculoColor)
        {
            using (var context = new MCCMEntities())
            {
                vehiculoColor.TF_Fecha_Creacion = DateTime.Now;
                vehiculoColor.TB_Eliminado = false;
                context.TMCCM_C_Vehiculo_Color.Add(vehiculoColor);
                context.SaveChanges();

            }

        }
    }
}
