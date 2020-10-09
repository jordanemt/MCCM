using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadArmaNegocio
    {
        EntidadArmaDatos entidadArmaDatos = new EntidadArmaDatos();
        public void InsertarEntidadArma(TMCCM_EntidadArmaDTO entidadArmaDTO)
        {
            entidadArmaDatos.InsertarEntidadArma(entidadArmaDTO);
        }

        public void ActualizarEntidadArma(TMCCM_EntidadArmaDTO entidadArmaDTO)
        {
            entidadArmaDatos.ActualizarEntidadArma(entidadArmaDTO);
        }

        public string EliminarEntidadArma(int ID)
        {
            entidadArmaDatos.EliminarEntidadArma(ID);
            return "S";
        }
        public List<TMCCM_EntidadArmaDTO> ListarEntidadArmas()
        {
            return entidadArmaDatos.ListarEntidadArmas();
        }

        public TMCCM_EntidadArmaDTO ObtenerEntidadArmaPorID(int ID)
        {
            return entidadArmaDatos.ObtenerEntidadArmaPorID(ID);
        }
    }
}
