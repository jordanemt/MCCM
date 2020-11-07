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
    public class C_UbicacionCantonDatos
    {
        public string ListarUbicacionCanton(int idProvincia)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from ubicacionCantonItem in context.TMCCM_C_Ubicacion_Canton
                              where ubicacionCantonItem.TB_Eliminado == false
                              where ubicacionCantonItem.TN_ID_Provincia == idProvincia
                              select new
                              {
                                  TN_ID_Canton = ubicacionCantonItem.TN_ID_Canton,
                                  TN_ID_Provincia = ubicacionCantonItem.TN_ID_Provincia,
                                  TC_Descripcion = ubicacionCantonItem.TC_Descripcion
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
            }
        public void InsertarUbicacionCanton(TMCCM_C_Ubicacion_Canton ubicacionCanton)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                ubicacionCanton.TF_Fecha_Creacion = DateTime.Now;
                ubicacionCanton.TB_Eliminado = false;
                context.TMCCM_C_Ubicacion_Canton.Add(ubicacionCanton);
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

