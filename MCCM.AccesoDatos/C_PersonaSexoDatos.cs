using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaSexoDatos
    {
        public List<TMCCM_C_PersonaSexoDTO> ListarPersonaSexo()
        {
            List<TMCCM_C_PersonaSexoDTO> personaSexo = null;

            using (var context = new MCCMEntities())
            {
                personaSexo = context.TMCCM_C_Persona_Sexo.Where(c => c.TB_Eliminado == false)
                  .Select(sexoItem => new TMCCM_C_PersonaSexoDTO()
                  {
                      TN_ID_Sexo = sexoItem.TN_ID_Sexo,
                      TC_Descripcion = sexoItem.TC_Descripcion,
                      TB_Eliminado = sexoItem.TB_Eliminado
                  }).ToList<TMCCM_C_PersonaSexoDTO>();
            }

            return personaSexo;
        }

        public TMCCM_C_Persona_Sexo ObtenerPorPersonaSexoID(int ID)
        {
            TMCCM_C_Persona_Sexo aux;
            using (var context = new MCCMEntities())
            {
                aux = (from sexoItem in context.TMCCM_C_Persona_Sexo
                       select new TMCCM_C_Persona_Sexo()
                       {
                           TN_ID_Sexo = sexoItem.TN_ID_Sexo,
                           TC_Descripcion = sexoItem.TC_Descripcion,
                           TB_Eliminado = sexoItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Sexo == ID).Single();
            }
            return aux;
        }
    }

}

