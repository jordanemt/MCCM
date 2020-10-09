using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadPersonaNegocio
    {

        EntidadPersonaDatos entidadPersonaDatos = new EntidadPersonaDatos();
        public void InsertarEntidadPersona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            entidadPersonaDatos.InsertarEntidadPersona(entidadPersonaDTO);
        }

        public void ActualizarEntidadPersona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            entidadPersonaDatos.ActualizarEntidadPersona(entidadPersonaDTO);
        }

        public string EliminarEntidadPersona(int ID)
        {
            entidadPersonaDatos.EliminarEntidadPersona(ID);
            return "S";
        }
        public List<TMCCM_EntidadPersonaDTO> ListarEntidadPersonas()
        {
            return entidadPersonaDatos.ListarEntidadPersonas();
        }

        public TMCCM_EntidadPersonaDTO ObtenerEntidadPersonaPorID(int ID)
        {
            return entidadPersonaDatos.ObtenerEntidadPersonaPorID(ID);
        }

    }
}
