using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaJuridicaTipoOrganizacionNegocio
    {
        C_PersonaJuridicaTipoOrganizacionDatos c_PersonaJuridicaTipoOrganizacion = new C_PersonaJuridicaTipoOrganizacionDatos();

        public string ListarPersonaJuridicaTipoOrganización()
        {
           
            return c_PersonaJuridicaTipoOrganizacion.ListarPersonaJuridicaTipoOrganizacion();
        }
        public void InsertarPersonaJuridicaTipoOrganizacion(TMCCM_C_Persona_Juridica_Tipo_Organización personaJuridicaTipoOrganización)
        {
            c_PersonaJuridicaTipoOrganizacion.InsertarPersonaJuridicaTipoOrganizacion(personaJuridicaTipoOrganización);
        }
    }
}
