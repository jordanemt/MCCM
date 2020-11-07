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
    public class C_PersonaTipoIdentificacionDatos
    {
        public string ListarPersonaTipoIdentificacion()
        {

            using (var context = new MCCMEntities())
            {
                var anonimo = from tipoIdentificacionItem in context.TMCCM_C_Persona_Tipo_Identificacion
                              select new
                              {
                                  TN_ID_Tipo_Identificacion = tipoIdentificacionItem.TN_ID_Tipo_Identificacion,
                                  TC_Descripcion = tipoIdentificacionItem.TC_Descripcion

                              };
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }

        }

        public void InsertarPersonaTipoIdentificacion(TMCCM_C_Persona_Tipo_Identificacion personaTipoIdentificacion)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                personaTipoIdentificacion.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_C_Persona_Tipo_Identificacion.Add(personaTipoIdentificacion);
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
