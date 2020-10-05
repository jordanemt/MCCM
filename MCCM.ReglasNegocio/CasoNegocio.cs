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

        public List<TMCCM_CasoDTO> ListarCasos() {
            return casoDatos.ListarCasos();
        }

        public TMCCM_Caso ObtenerCasoPorID(int ID) {
            return casoDatos.ObtenerCasoPorID(ID);
        }

    }
}
