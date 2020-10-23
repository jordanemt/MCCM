using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_TipoArmaNegocio
    {
        C_TipoArmaDatos c_TipoArmaDatos = new C_TipoArmaDatos();
        public List<TMCCM_C_TipoArmaDTO> ListaTipoArma()
        {
           
            return c_TipoArmaDatos.ListaTipoArma();
        }
        public TMCCM_C_Arma_Tipo_Arma ObtenerTipoArmaPorID(int ID)
        {
            return c_TipoArmaDatos.ObtenerTipoArmaPorID(ID);
        }

    }
}
