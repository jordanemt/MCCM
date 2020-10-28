using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaGeneroDatos
    {
        public List<TMCCM_C_PersonaGeneroDTO> ListarPersonaGenero()
        {
            List<TMCCM_C_PersonaGeneroDTO> personaGeneros = null;

            using (var context = new MCCMEntities())
            {
                personaGeneros = context.TMCCM_C_Persona_Genero.Where(c => c.TB_Eliminado == false)
                  .Select(generoItem => new TMCCM_C_PersonaGeneroDTO()
                  {
                      TN_ID_Genero = generoItem.TN_ID_Genero,
                      TC_Descripcion = generoItem.TC_Descripcion,
                  }).ToList<TMCCM_C_PersonaGeneroDTO>();
            }

            return personaGeneros;
        }

    }
}

