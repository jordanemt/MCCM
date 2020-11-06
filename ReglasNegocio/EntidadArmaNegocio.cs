using MCCM.AccesoDatos;
using MCCM.Entidad;
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
        public void InsertarEntidadArma(TMCCM_Entidad_Arma entidadArma)
        {
            entidadArmaDatos.InsertarEntidadArma(entidadArma);
        }

        public void ActualizarEntidadArma(TMCCM_Entidad_Arma entidadArma)
        {
            entidadArmaDatos.ActualizarEntidadArma(entidadArma);
        }

        public string EliminarEntidadArma(int ID)
        {
            entidadArmaDatos.EliminarEntidadArma(ID);
            return "S";
        }
        public string ListarEntidadArmas( int caso )
        {
            return entidadArmaDatos.ListarEntidadArmas(caso);
        }

        public string ObtenerEntidadArmaPorID(int ID)
        {
            return entidadArmaDatos.ObtenerEntidadArmaPorID(ID);
        }
    }
}
