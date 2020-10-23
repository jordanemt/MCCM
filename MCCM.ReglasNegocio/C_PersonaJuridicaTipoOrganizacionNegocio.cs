using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaJuridicaTipoOrganizacionNegocio
    {
        C_PersonaJuridicaTipoOrganizacionDatos c_PersonaJuridicaTipoOrganizacion = new C_PersonaJuridicaTipoOrganizacionDatos();

        public List<TMCCM_C_PersonaJuridicaTipoOrganizaciónDTO> ListarPersonaJuridicaTipoOrganización()
        {
           
            return c_PersonaJuridicaTipoOrganizacion.ListarPersonaJuridicaTipoOrganización();
        }

        public TMCCM_C_Persona_Juridica_Tipo_Organización ObtenerPorTipoOrganizaciónID(int ID)
        {
           
            return c_PersonaJuridicaTipoOrganizacion.ObtenerPorTipoOrganizaciónID(ID);
        }

    }
}
