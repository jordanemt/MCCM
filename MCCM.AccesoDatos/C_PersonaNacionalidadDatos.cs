using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaNacionalidadDatos
    {
        public List<TMCCM_C_PersonaNacionalidadDTO> ListarPersonaNacionalidad()
        {
            List<TMCCM_C_PersonaNacionalidadDTO> personaNacionalidades = null;

            using (var context = new MCCMEntities())
            {
                personaNacionalidades = context.TMCCM_C_Persona_Nacionalidad
                  .Select(nacionalidadItem => new TMCCM_C_PersonaNacionalidadDTO()
                  {
                      TN_ID_Nacionalidad = nacionalidadItem.TN_ID_Nacionalidad,
                      TC_Descripcion = nacionalidadItem.TC_Descripcion,
                      TF_Fecha_Creacion = nacionalidadItem.TF_Fecha_Creacion
                  }).ToList<TMCCM_C_PersonaNacionalidadDTO>();
            }

            return personaNacionalidades;
        }

        public TMCCM_C_Persona_Nacionalidad ObtenerPorPersonaNacionalidadID(int ID)
        {
            TMCCM_C_Persona_Nacionalidad aux;
            using (var context = new MCCMEntities())
            {
                aux = (from nacionalidadItem in context.TMCCM_C_Persona_Nacionalidad
                       select new TMCCM_C_Persona_Nacionalidad()
                       {
                           TN_ID_Nacionalidad = nacionalidadItem.TN_ID_Nacionalidad,
                           TC_Descripcion = nacionalidadItem.TC_Descripcion,
                           TF_Fecha_Creacion = nacionalidadItem.TF_Fecha_Creacion
                       }).Where(x => x.TN_ID_Nacionalidad == ID).Single();
            }
            return aux;
        }
    }
}
