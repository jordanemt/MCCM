using MCCM.AccesoDatos;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadPersonaJuridicaNegocio
    {
        EntidadPersonaJuridicaDatos entidadPersonaJuridicaDatos = new EntidadPersonaJuridicaDatos();
        public void InsertarEntidadPersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            entidadPersonaJuridicaDatos.InsertarEntidadPersonaJuridica(entidadPersonaJuridica);
        }

        public void ActualizarEntidadPersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            entidadPersonaJuridicaDatos.ActualizarEntidadPersonaJuridica(entidadPersonaJuridica);
        }

        public string EliminarEntidadPersonaJuridica(int ID)
        {
            entidadPersonaJuridicaDatos.EliminarEntidadPersonaJuridica(ID);
            return "S";
        }
        public string ListarEntidadPersonaJuridicas(int caso)
        {
            return entidadPersonaJuridicaDatos.ListarEntidadPersonaJuridicas(caso);
        }

        public string ObtenerEntidadPersonaJuridicaPorID(int ID)
        {
            return entidadPersonaJuridicaDatos.ObtenerEntidadPersonaJuridicaPorID(ID);
        }

    }
}
