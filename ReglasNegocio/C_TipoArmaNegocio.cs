using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_TipoArmaNegocio
    {
        C_TipoArmaDatos c_TipoArmaDatos = new C_TipoArmaDatos();
        public string ListaTipoArma()
        {
           
            return c_TipoArmaDatos.ListaTipoArma();
        }
        public void InsertarTipoArma(TMCCM_C_Arma_Tipo_Arma tipoArma)
        {
            c_TipoArmaDatos.InsertarTipoArma(tipoArma);
        }

    }
}
