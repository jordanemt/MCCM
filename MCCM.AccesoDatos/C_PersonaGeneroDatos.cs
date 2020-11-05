using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaGeneroDatos
    {
        public string ListarPersonaGenero()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from generoItem in context.TMCCM_C_Persona_Genero
                              where generoItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Genero = generoItem.TN_ID_Genero,
                                  TC_Descripcion = generoItem.TC_Descripcion,
                              };

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarPersonaGenero(TMCCM_C_Persona_Genero personaGenero)
        {
            using (var context = new MCCMEntities())
            {
                personaGenero.TB_Eliminado = false;
                context.TMCCM_C_Persona_Genero.Add(personaGenero);
                context.SaveChanges();

            }

        }

    }
}

