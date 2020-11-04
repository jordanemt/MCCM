using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;
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
        public void InsertarEntidadPersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            entidadPersonaJuridicaDatos.InsertarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
        }

        public void ActualizarEntidadPersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            entidadPersonaJuridicaDatos.ActualizarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
        }

        public string EliminarEntidadPersonaJuridica(int ID)
        {
            entidadPersonaJuridicaDatos.EliminarEntidadPersonaJuridica(ID);
            return "S";
        }
        public List<TMCCM_EntidadPersonaJuridicaDTO> ListarEntidadPersonaJuridicas(int caso)
        {
            return entidadPersonaJuridicaDatos.ListarEntidadPersonaJuridicas(caso);
        }

        public TMCCM_EntidadPersonaJuridicaDTO ObtenerEntidadPersonaJuridicaPorID(int ID)
        {
            return entidadPersonaJuridicaDatos.ObtenerEntidadPersonaJuridicaPorID(ID);
        }

    }
}
