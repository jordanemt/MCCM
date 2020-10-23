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
    public class C_TipoDrogaNegocio
    {
        C_TipoDrogaDatos c_TipoDrogaDatos = new C_TipoDrogaDatos();
        public List<TMCCM_C_TipoDrogaDTO> ListarTiposDroga()
        { 
            return c_TipoDrogaDatos.ListarTiposDroga();
        }

        public TMCCM_C_Droga_Tipo_Droga ObtenerTipoDrogaPorID(int ID)
        {
            return c_TipoDrogaDatos.ObtenerTipoDrogaPorID(ID);
        }
    }
}

