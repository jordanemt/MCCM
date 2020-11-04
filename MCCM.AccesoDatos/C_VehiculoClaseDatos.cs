using MCCM.Entidad;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_VehiculoClaseDatos
    {
        public string ListarVehiculoClase()
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from vehiculoClaseItem in context.TMCCM_C_Vehiculo_Clase
                              where vehiculoClaseItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Clase_Vehiculo = vehiculoClaseItem.TN_ID_Clase_Vehiculo,
                                  TC_Descripcion = vehiculoClaseItem.TC_Descripcion
                              };

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarVehiculoClase(TMCCM_C_Vehiculo_Clase vehiculoClase)
        {
            using (var context = new MCCMEntities())
            {
                vehiculoClase.TF_Fecha_Creacion = DateTime.Now;
                vehiculoClase.TB_Eliminado = false;
                context.TMCCM_C_Vehiculo_Clase.Add(vehiculoClase);
                context.SaveChanges();

            }

        }
    }
}
