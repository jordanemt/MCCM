using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class CasoDatos
    {
        public void InsertarCaso(TMCCM_Caso caso)
        {
            using (var context = new MCCMEntities())
            {
                caso.TB_Eliminado = true;
                caso.TF_Fecha = DateTime.Now;
                context.TMCCM_Caso.Add(caso);
                context.SaveChanges();
            }
        }

        public List<TMCCM_CasoDTO> ListarCasos()
        {
            List<TMCCM_CasoDTO> casosDTO = null;

            using (var context = new MCCMEntities())
            {
                casosDTO = context.TMCCM_Caso
                  .Select(casoItem => new TMCCM_CasoDTO()
                  {
                      TN_ID_Caso = casoItem.TN_ID_Caso,
                      TC_Nombre_Caso = casoItem.TC_Nombre_Caso,
                      TC_Delito = casoItem.TC_Delito,
                      TF_Fecha = casoItem.TF_Fecha
                  }).ToList<TMCCM_CasoDTO>();
            }

            return casosDTO;
        }

        public TMCCM_Caso ObtenerCasoPorID(int ID)
        {
            TMCCM_Caso aux;
            using (var context = new MCCMEntities())
            {
                aux = context.TMCCM_Caso.Where(x => x.TN_ID_Caso == ID).Single(); 
            }
            return aux;
        }

    }



}
