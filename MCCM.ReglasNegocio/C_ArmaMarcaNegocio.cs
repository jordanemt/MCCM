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

        C_ArmaMarcaDatos c_ArmaMarcaDatos = new C_ArmaMarcaDatos();
        public string ListaArmaMarca()
        {

            return  c_ArmaMarcaDatos.ListaArmaMarca();
        }
        public void InsertarArmaMarca(TMCCM_C_Arma_Marca armaMarca)
        {
            c_ArmaMarcaDatos.InsertarArmaMarca(armaMarca);
        }

    }

}

