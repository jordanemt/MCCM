using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using MCCM.Entidad.DTO;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_ArmaMarcaDatos
    {
        public List<TMCCM_C_ArmaMarcaDTO> ListaArmaMarca()
        {
            List<TMCCM_C_ArmaMarcaDTO> arma_Marcas = null;

            using (var context = new MCCMEntities())
            {
                arma_Marcas = context.TMCCM_C_Arma_Marca.Where(c => c.TB_Eliminado == false)
                  .Select(armaMarcaItem => new TMCCM_C_ArmaMarcaDTO()
                  {
                      TN_ID_Marca_Arma = armaMarcaItem.TN_ID_Marca_Arma,
                      TC_Descripcion = armaMarcaItem.TC_Descripcion,
                  }).ToList<TMCCM_C_ArmaMarcaDTO>();
            }

            return arma_Marcas;
        }

     

    }
}
