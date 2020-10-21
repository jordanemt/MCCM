using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_TipoDrogaDatos
    {
        public List<TMCCM_C_TipoDatosDTO> ListarTiposDroga()
        {
            List<TMCCM_C_TipoDatosDTO> droga_Tipo_Drogas = null;

            using (var context = new MCCMEntities())
            {
                droga_Tipo_Drogas = context.TMCCM_C_Droga_Tipo_Droga.Where(c => c.TB_Eliminado == true)
                  .Select(tipoDrogaItem => new TMCCM_C_TipoDatosDTO()
                  {
                      TN_ID_Tipo_Droga = tipoDrogaItem.TN_ID_Tipo_Droga,
                      TF_Fecha_Creacion = tipoDrogaItem.TF_Fecha_Creacion,
                      TC_Nombre = tipoDrogaItem.TC_Nombre,
                      TC_Descripcion = tipoDrogaItem.TC_Descripcion,
                      TB_Eliminado = tipoDrogaItem.TB_Eliminado
                  }).ToList<TMCCM_C_TipoDatosDTO>();
            }

            return droga_Tipo_Drogas;
        }

        public TMCCM_C_Droga_Tipo_Droga ObtenerTipoDrogaPorID(int ID)
        {
            TMCCM_C_Droga_Tipo_Droga aux;
            using (var context = new MCCMEntities())
            {
                aux = (from tipoDrogaItem in context.TMCCM_C_Droga_Tipo_Droga
                       select new TMCCM_C_Droga_Tipo_Droga()
                       {
                           TN_ID_Tipo_Droga = tipoDrogaItem.TN_ID_Tipo_Droga,
                           TF_Fecha_Creacion = tipoDrogaItem.TF_Fecha_Creacion,
                           TC_Nombre = tipoDrogaItem.TC_Nombre,
                           TC_Descripcion = tipoDrogaItem.TC_Descripcion,
                           TB_Eliminado = tipoDrogaItem.TB_Eliminado
                       }).Where(x => x.TN_ID_Tipo_Droga == ID).Single();
            }
            return aux;
        }
    }
    


}

