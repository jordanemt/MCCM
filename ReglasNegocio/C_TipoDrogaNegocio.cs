using MCCM.AccesoDatos;
using MCCM.Entidad;
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
        public string ListarTiposDroga()
        { 
            return c_TipoDrogaDatos.ListarTiposDroga();
        }
        public void InsertarTipoDroga(TMCCM_C_Droga_Tipo_Droga tipoDroga)
        {
            c_TipoDrogaDatos.InsertarTipoDroga(tipoDroga);
        }
    }
}

