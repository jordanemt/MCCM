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
                  }).ToList<TMCCM_C_PersonaNacionalidadDTO>();
            }

            return personaNacionalidades;
        }
        public void InsertarPersonaNacionalidad(TMCCM_C_Persona_Nacionalidad personaNacionalidad)
        {
            using (var context = new MCCMEntities())
            {
                personaNacionalidad.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_C_Persona_Nacionalidad.Add(personaNacionalidad);
                context.SaveChanges();

            }

        }

    }
}
