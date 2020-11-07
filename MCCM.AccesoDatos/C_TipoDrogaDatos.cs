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
    public class C_TipoDrogaDatos
    {
        public string ListarTiposDroga()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from tipoDrogaItem in context.TMCCM_C_Droga_Tipo_Droga
                              where tipoDrogaItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Tipo_Droga = tipoDrogaItem.TN_ID_Tipo_Droga,
                                  TC_Nombre = tipoDrogaItem.TC_Nombre,
                                  TC_Descripcion = tipoDrogaItem.TC_Descripcion
                              };


                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

        public void InsertarTipoDroga(TMCCM_C_Droga_Tipo_Droga tipoDroga)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                tipoDroga.TF_Fecha_Creacion = DateTime.Now;
                tipoDroga.TB_Eliminado = false;
                context.TMCCM_C_Droga_Tipo_Droga.Add(tipoDroga);
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

