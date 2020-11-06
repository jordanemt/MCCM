using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_UbicacionProvinciaDatos
    {
        public string ListarUbicacionProvincia()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from ubicacionProvinciaItem in context.TMCCM_C_Ubicacion_Provincia
                              where ubicacionProvinciaItem.TB_Eliminado == false
                              select new

                              {
                                  TN_ID_Provincia = ubicacionProvinciaItem.TN_ID_Provincia,
                                  TC_Descripcion = ubicacionProvinciaItem.TC_Descripcion,
                              };



                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarUbicacionProvincia(TMCCM_C_Ubicacion_Provincia ubicacionProvincia)
        {
            using (var context = new MCCMEntities())
            {
                ubicacionProvincia.TF_Fecha_Creacion = DateTime.Now;
                ubicacionProvincia.TB_Eliminado = false;
                context.TMCCM_C_Ubicacion_Provincia.Add(ubicacionProvincia);
                context.SaveChanges();

            }

        }
    }

}

