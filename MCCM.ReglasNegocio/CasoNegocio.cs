using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.AccesoDatos;
using MCCM.Entidad;
using MCCM.Entidad.DTO;

namespace MCCM.ReglasNegocio
{
    public class CasoNegocio
    {
        AccesoDatos.CasoDatos casoDatos = new AccesoDatos.CasoDatos();

        public void InsertarCaso(TMCCM_Caso caso) {
            casoDatos.InsertarCaso(caso);
        }

        public void ActualizarCaso(TMCCM_Caso caso)
        {
            casoDatos.ActualizarCaso(caso);
        }

        public string EliminarCaso(int ID) {
            casoDatos.EliminarCaso(ID);
            return "S";
        }
        public string ListarCasos() {
            return casoDatos.ListarCasos();
        }

        public string ObtenerCasoPorID(int ID) {
            return casoDatos.ObtenerCasoPorID(ID);
        }

    }
}
