using MCCM.AccesoDatos;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadDrogaNegocio
    {
        EntidadDrogaDatos entidadDrogaDatos = new EntidadDrogaDatos();
        public void InsertarEntidadDroga(TMCCM_Entidad_Droga entidadDroga)
        {
            entidadDrogaDatos.InsertarEntidadDroga(entidadDroga);
        }
        public void ActualizarEntidadDroga(TMCCM_Entidad_Droga entidadDroga)
        {
            if (entidadDroga.TB_Verificado == null)
            {
                entidadDroga.TB_Verificado = false;
            }
            entidadDrogaDatos.ActualizarEntidadDroga(entidadDroga);
        }

        public string EliminarEntidadDroga(int ID)
        {
            entidadDrogaDatos.EliminarEntidadDroga(ID);
            return "S";
        }
        public string ListarEntidadDrogas(int caso)
        {
            return entidadDrogaDatos.ListarEntidadDroga(caso);
        }

        public string ObtenerEntidadDrogaPorID(int ID)
        {
            return entidadDrogaDatos.ObtenerEntidadDrogaPorID(ID);
        }
    }
}
