using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MCCM.AccesoDatos.exceptions;

namespace MCCM.AccesoDatos
{
    public class C_ArmaMarcaDatos
    {
        public string ListaArmaMarca()
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from armaMarcaItem in context.TMCCM_C_Arma_Marca
                              where armaMarcaItem.TB_Eliminado == false
                              select new
                              {
                      TN_ID_Marca_Arma = armaMarcaItem.TN_ID_Marca_Arma,
                      TC_Descripcion = armaMarcaItem.TC_Descripcion,
                  };


                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarArmaMarca(TMCCM_C_Arma_Marca armaMarca)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                armaMarca.TB_Eliminado = false;
                context.TMCCM_C_Arma_Marca.Add(armaMarca);
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
