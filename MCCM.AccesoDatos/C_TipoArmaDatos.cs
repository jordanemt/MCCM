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
    public class C_TipoArmaDatos
    {
        public string ListaTipoArma()
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from armaTipoItem in context.TMCCM_C_Arma_Tipo_Arma
                              where armaTipoItem.TB_Eliminado == false
                              select new
                              {
                              TN_ID_Tipo_Arma = armaTipoItem.TN_ID_Tipo_Arma,
                              TC_Descripcion = armaTipoItem.TC_Descripcion,

                  };


                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarTipoArma(TMCCM_C_Arma_Tipo_Arma tipoArma)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                tipoArma.TB_Eliminado = false;
                context.TMCCM_C_Arma_Tipo_Arma.Add(tipoArma);
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

