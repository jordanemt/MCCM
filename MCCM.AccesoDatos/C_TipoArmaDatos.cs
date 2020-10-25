using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_TipoArmaDatos
    {
        public List<TMCCM_C_TipoArmaDTO> ListaTipoArma()
        {
            List<TMCCM_C_TipoArmaDTO> arma_Tipos = null;

            using (var context = new MCCMEntities())
            {
                arma_Tipos = context.TMCCM_C_Arma_Tipo_Arma.Where(c => c.TB_Eliminado == false)
                  .Select(armaTipoItem => new TMCCM_C_TipoArmaDTO()
                  {
                      TN_ID_Tipo_Arma = armaTipoItem.TN_ID_Tipo_Arma,
                      TC_Descripcion = armaTipoItem.TC_Descripcion,

                  }).ToList<TMCCM_C_TipoArmaDTO>();
            }

            return arma_Tipos;
        }

    }
}

