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
                      TB_Eliminado = generoItem.TB_Eliminado
                  }).ToList<TMCCM_C_PersonaGeneroDTO>();
            }

            return personaGeneros;
        }

        public TMCCM_C_Persona_Genero ObtenerPorPersonaGeneroID(int ID)
        {
            TMCCM_C_Persona_Genero aux;
            using (var context = new MCCMEntities())
            {
                aux = (from generoItem in context.TMCCM_C_Persona_Genero
                       select new TMCCM_C_Persona_Genero()
                       {
                           TN_ID_Genero = generoItem.TN_ID_Genero,
                           TC_Descripcion = generoItem.TC_Descripcion,
                           TB_Eliminado = generoItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Genero == ID).Single();
            }
            return aux;
        }
    }
}

