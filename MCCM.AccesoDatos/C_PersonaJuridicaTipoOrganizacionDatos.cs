using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaJuridicaTipoOrganizacionDatos
    {
        public List<TMCCM_C_PersonaJuridicaTipoOrganizaciónDTO> ListarPersonaJuridicaTipoOrganización()
        {
            List<TMCCM_C_PersonaJuridicaTipoOrganizaciónDTO> personaJuridicaTipoOrganización = null;

            using (var context = new MCCMEntities())
            {
                personaJuridicaTipoOrganización = context.TMCCM_C_Persona_Juridica_Tipo_Organización.Where(c => c.TB_Eliminado == false)
                  .Select(tipoOrganizacionItem => new TMCCM_C_PersonaJuridicaTipoOrganizaciónDTO()
                  {
                      TN_ID_Tipo_Organizacion = tipoOrganizacionItem.TN_ID_Tipo_Organizacion,
                      TC_Descripcion = tipoOrganizacionItem.TC_Descripcion,
                      TB_Eliminado = tipoOrganizacionItem.TB_Eliminado
                  }).ToList<TMCCM_C_PersonaJuridicaTipoOrganizaciónDTO>();
            }

            return personaJuridicaTipoOrganización;
        }

        public TMCCM_C_Persona_Juridica_Tipo_Organización ObtenerPorTipoOrganizaciónID(int ID)
        {
            TMCCM_C_Persona_Juridica_Tipo_Organización aux;
            using (var context = new MCCMEntities())
            {
                aux = (from tipoOrganizacionItem in context.TMCCM_C_Persona_Juridica_Tipo_Organización
                       select new TMCCM_C_Persona_Juridica_Tipo_Organización()
                       {
                           TN_ID_Tipo_Organizacion = tipoOrganizacionItem.TN_ID_Tipo_Organizacion,
                           TC_Descripcion = tipoOrganizacionItem.TC_Descripcion,
                           TB_Eliminado = tipoOrganizacionItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Tipo_Organizacion== ID).Single();
            }
            return aux;
        }
    }
}
