using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;

namespace MCCM.ReglasNegocio
{
   public class C_ArmaMarcaNegocio
    {

        C_TipoArmaDatos c_TipoArmaDatos = new C_TipoArmaDatos();
        public List<TMCCM_C_TipoArmaDTO> ListaTipoArma()
        {

            return  c_TipoArmaDatos.ListaTipoArma();
        }

    }

}

