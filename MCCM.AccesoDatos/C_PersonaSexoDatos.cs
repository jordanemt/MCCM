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
    public class C_PersonaSexoDatos
    {
        public string ListarPersonaSexo()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from sexoItem in context.TMCCM_C_Persona_Sexo
                              where sexoItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Sexo = sexoItem.TN_ID_Sexo,
                                  TC_Descripcion = sexoItem.TC_Descripcion
                              };

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarPersonaSexo(TMCCM_C_Persona_Sexo personaSexo)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    personaSexo.TB_Eliminado = false;
                    context.TMCCM_C_Persona_Sexo.Add(personaSexo);
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

