using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class EntidadPersonaJuridicaDatos
    {
        public void InsertarEntidadPersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            using (var context = new MCCMEntities())
            {
                entidadPersonaJuridica.TB_Eliminado = false;
                context.TMCCM_Entidad_Persona_Juridica.Add(entidadPersonaJuridica);
                context.SaveChanges();

            }
        }

        public void ModificarEntidadPersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona_Juridica.SingleOrDefault(b => b.TN_ID_Persona_Juridica == entidadPersonaJuridica.TN_ID_Persona_Juridica);
                if (result != null)
                {
                    result.TN_ID_Persona_Juridica = entidadPersonaJuridica.TN_ID_Persona_Juridica;
                    result.TC_ID_Cedula_Juridica = entidadPersonaJuridica.TC_ID_Cedula_Juridica;
                    result.TC_Nombre_Organización = entidadPersonaJuridica.TC_Nombre_Organización;
                    result.TC_Nombre_Comercial = entidadPersonaJuridica.TC_Nombre_Comercial;
                    result.TN_ID_Tipo_Organizacion = entidadPersonaJuridica.TN_ID_Tipo_Organizacion;
                    result.TC_Sitio_Web = entidadPersonaJuridica.TC_Sitio_Web;
                    result.TC_Comentario = entidadPersonaJuridica.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadPersonaJuridica.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadPersonaJuridica.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadPersonaJuridica.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadPersonaJuridica.TC_Modificado_Por;
                    result.TB_Verificado = entidadPersonaJuridica.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEntidadPersonaJuridica(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona_Juridica.SingleOrDefault(b => b.TN_ID_Persona_Juridica == ID);
                if (result != null)
                {
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public string ListarEntidadPersonaJuridicas(int caso)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = from personaJuridicaItem in context.TMCCM_Entidad_Persona_Juridica
                              from tipoItem in context.TMCCM_C_Persona_Juridica_Tipo_Organización
                              where personaJuridicaItem.TB_Eliminado == false
                              where personaJuridicaItem.TN_ID_Caso == caso
                              where personaJuridicaItem.TN_ID_Tipo_Organizacion == tipoItem.TN_ID_Tipo_Organizacion
                              select new
                              {
                                  TN_ID_Persona_Juridica = personaJuridicaItem.TN_ID_Persona_Juridica,
                                  TC_ID_Cedula_Juridica = personaJuridicaItem.TC_ID_Cedula_Juridica,
                                  TC_Nombre_Organización = personaJuridicaItem.TC_Nombre_Organización,
                                  TC_Tipo_Organizacion = tipoItem.TC_Descripcion
                              };


                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public string ObtenerEntidadPersonaJuridicaPorID(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from personaJuridicaItem in context.TMCCM_Entidad_Persona_Juridica
                               where personaJuridicaItem.TB_Eliminado == false
                               where personaJuridicaItem.TN_ID_Persona_Juridica == ID
                               select new
                               {
                                   TN_ID_Persona_Juridica = personaJuridicaItem.TN_ID_Persona_Juridica,
                                   TN_ID_Caso = personaJuridicaItem.TN_ID_Caso,
                                   TC_ID_Cedula_Juridica = personaJuridicaItem.TC_ID_Cedula_Juridica,
                                   TC_Nombre_Organización = personaJuridicaItem.TC_Nombre_Organización,
                                   TC_Nombre_Comercial = personaJuridicaItem.TC_Nombre_Comercial,
                                   TN_ID_Tipo_Organizacion = personaJuridicaItem.TN_ID_Tipo_Organizacion,
                                   TC_Sitio_Web = personaJuridicaItem.TC_Sitio_Web,
                                   TC_Comentario = personaJuridicaItem.TC_Comentario,
                                   TF_Fecha_Creacion = personaJuridicaItem.TF_Fecha_Creacion,
                                   TF_Fecha_Modificacion = personaJuridicaItem.TF_Fecha_Modificacion,
                                   TC_Creado_Por = personaJuridicaItem.TC_Creado_Por,
                                   TC_Modificado_Por = personaJuridicaItem.TC_Modificado_Por,
                                   TB_Verificado = personaJuridicaItem.TB_Verificado
                               }).Single();
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

    }


}

