using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
   public class C_PersonaTipoIdentificacionDatos
    {
        public List<TMCCM_C_PersonaTipoIdentificacionDTO> ListarPersonaTipoIdentificacion()
        {
            List<TMCCM_C_PersonaTipoIdentificacionDTO> personaTipoIdentificaciones = null;

            using (var context = new MCCMEntities())
            {
                personaTipoIdentificaciones = context.TMCCM_C_Persona_Tipo_Identificacion
                  .Select(tipoIdentificacionItem => new TMCCM_C_PersonaTipoIdentificacionDTO()
                  {
                      TN_ID_Tipo_Identificacion = tipoIdentificacionItem.TN_ID_Tipo_Identificacion,
                      TC_Descripcion = tipoIdentificacionItem.TC_Descripcion,
                      TC_Mascara = tipoIdentificacionItem.TC_Mascara,
                      TF_Fecha_Creacion= tipoIdentificacionItem.TF_Fecha_Creacion,

                  }).ToList<TMCCM_C_PersonaTipoIdentificacionDTO>();
            }

            return personaTipoIdentificaciones;
        }

        public TMCCM_C_Persona_Tipo_Identificacion ObtenerPorTipoIdentificacionID(int ID)
        {
            TMCCM_C_Persona_Tipo_Identificacion aux;
            using (var context = new MCCMEntities())
            {
                aux = (from tipoIdentificacionItem in context.TMCCM_C_Persona_Tipo_Identificacion
                       select new TMCCM_C_Persona_Tipo_Identificacion()
                       {
                           TN_ID_Tipo_Identificacion = tipoIdentificacionItem.TN_ID_Tipo_Identificacion,
                           TC_Descripcion = tipoIdentificacionItem.TC_Descripcion,
                           TC_Mascara = tipoIdentificacionItem.TC_Mascara,
                           TF_Fecha_Creacion = tipoIdentificacionItem.TF_Fecha_Creacion,
                       }).Where(x => x.TN_ID_Tipo_Identificacion == ID).Single();
            }
            return aux;
        }

    }
}
