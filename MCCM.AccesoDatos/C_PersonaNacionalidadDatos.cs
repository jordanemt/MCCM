using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class C_PersonaNacionalidadDatos
    {
        public string ListarPersonaNacionalidad()
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from nacionalidadItem in context.TMCCM_C_Persona_Nacionalidad
                              select new
                              {
                                  TN_ID_Nacionalidad = nacionalidadItem.TN_ID_Nacionalidad,
                                  TC_Descripcion = nacionalidadItem.TC_Descripcion,
                              };

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public void InsertarPersonaNacionalidad(TMCCM_C_Persona_Nacionalidad personaNacionalidad)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                personaNacionalidad.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_C_Persona_Nacionalidad.Add(personaNacionalidad);
                context.SaveChanges();

            }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }

        }

    }
}
