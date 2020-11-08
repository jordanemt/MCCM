using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaJuridicaTipoOrganizacionDatos
    {
        public string ListarPersonaJuridicaTipoOrganizacion()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from tipoOrganizacionItem in context.TMCCM_C_Persona_Juridica_Tipo_Organizacion
                              where tipoOrganizacionItem.TB_Eliminado == false
                              select new
                              {
                                  TN_ID_Tipo_Organizacion = tipoOrganizacionItem.TN_ID_Tipo_Organizacion,
                                  TC_Descripcion = tipoOrganizacionItem.TC_Descripcion
                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarPersonaJuridicaTipoOrganizacion(TMCCM_C_Persona_Juridica_Tipo_Organizacion personaJuridicaTipoOrganizacion)
        {
            using (var context = new MCCMEntities())
            {
                personaJuridicaTipoOrganizacion.TB_Eliminado = false;
                context.TMCCM_C_Persona_Juridica_Tipo_Organizacion.Add(personaJuridicaTipoOrganizacion);
                context.SaveChanges();

            }

        }
    }
}
