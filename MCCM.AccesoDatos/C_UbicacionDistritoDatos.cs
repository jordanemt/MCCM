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
    public class C_UbicacionDistritoDatos
    {
        public string ListarUbicacionDistrito(int idCanton)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from ubicacionDistritoItem in context.TMCCM_C_Ubicacion_Distrito
                              where ubicacionDistritoItem.TB_Eliminado == false
                              where ubicacionDistritoItem.TN_ID_Canton == idCanton
                              select new
                              {
                      TN_ID_Distrito= ubicacionDistritoItem.TN_ID_Distrito,
                      TN_ID_Canton = ubicacionDistritoItem.TN_ID_Canton,
                      TC_Descripcion = ubicacionDistritoItem.TC_Descripcion
                  };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }

        }
        public void InsertarUbicacionDistrito(TMCCM_C_Ubicacion_Distrito ubicacionDistrito)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                ubicacionDistrito.TF_Fecha_Creacion = DateTime.Now;
                ubicacionDistrito.TB_Eliminado = false;
                context.TMCCM_C_Ubicacion_Distrito.Add(ubicacionDistrito);
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

