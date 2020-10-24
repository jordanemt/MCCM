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
        public List<TMCCM_C_TipoDatosDTO> ListarTiposDroga()
        { 
            return c_TipoDrogaDatos.ListarTiposDroga();
        }

        public TMCCM_C_TipoDatosDTO ObtenerTipoDrogaPorID(int ID)
        {
            return null; //c_TipoDrogaDatos.ObtenerTipoDrogaPorID(ID);
        }
    }
}

