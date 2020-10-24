using MCCM.Entidad;
using MCCM.Entidad.DTO;
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
        Utilidades utilidades = new Utilidades();
        public void InsertarEntidadPersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            using (var context = new MCCMEntities())
            {
                context.TMCCM_Entidad_Persona_Juridica.Add(new TMCCM_Entidad_Persona_Juridica()
                {
                    TN_ID_Caso = entidadPersonaJuridicaDTO.TN_ID_Caso,
                    TC_ID_Cedula_Juridica = entidadPersonaJuridicaDTO.TC_ID_Cedula_Juridica,
                    TC_Nombre_Organización = entidadPersonaJuridicaDTO.TC_Nombre_Organización,
                    TC_Nombre_Comercial = entidadPersonaJuridicaDTO.TC_Nombre_Comercial,
                    TN_ID_Icono_Persona_Juridica = entidadPersonaJuridicaDTO.TN_ID_Icono_Persona_Juridica,
                    TB_Fotografia = utilidades.ConverToBytes(entidadPersonaJuridicaDTO.TB_Fotografia),
                    TN_ID_Tipo_Organizacion = entidadPersonaJuridicaDTO.TN_ID_Tipo_Organizacion,
                    TC_Sitio_Web = entidadPersonaJuridicaDTO.TC_Sitio_Web,
                    TC_Comentario = entidadPersonaJuridicaDTO.TC_Comentario,
                    TF_Fecha_Creacion = entidadPersonaJuridicaDTO.TF_Fecha_Creacion,
                    TF_Fecha_Modificacion = entidadPersonaJuridicaDTO.TF_Fecha_Modificacion,
                    TC_Creado_Por = entidadPersonaJuridicaDTO.TC_Creado_Por,
                    TC_Modificado_Por = "",
                    TB_Verificado = entidadPersonaJuridicaDTO.TB_Verificado,
                });

                context.SaveChanges();
            }
        }

        public void ActualizarEntidadPersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona_Juridica.SingleOrDefault(b => b.TN_ID_Persona_Juridica == entidadPersonaJuridicaDTO.TN_ID_Persona_Juridica);
                if (result != null)
                {
                    result.TN_ID_Persona_Juridica = entidadPersonaJuridicaDTO.TN_ID_Persona_Juridica;
                    result.TN_ID_Caso = entidadPersonaJuridicaDTO.TN_ID_Caso;
                    result.TC_ID_Cedula_Juridica = entidadPersonaJuridicaDTO.TC_ID_Cedula_Juridica;
                    result.TC_Nombre_Organización = entidadPersonaJuridicaDTO.TC_Nombre_Organización;
                    result.TC_Nombre_Comercial = entidadPersonaJuridicaDTO.TC_Nombre_Comercial;
                    result.TN_ID_Icono_Persona_Juridica = entidadPersonaJuridicaDTO.TN_ID_Icono_Persona_Juridica;
                    result.TB_Fotografia = utilidades.ConverToBytes(entidadPersonaJuridicaDTO.TB_Fotografia);
                    result.TN_ID_Tipo_Organizacion = entidadPersonaJuridicaDTO.TN_ID_Tipo_Organizacion;
                    result.TC_Sitio_Web = entidadPersonaJuridicaDTO.TC_Sitio_Web;
                    result.TC_Comentario = entidadPersonaJuridicaDTO.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadPersonaJuridicaDTO.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadPersonaJuridicaDTO.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadPersonaJuridicaDTO.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadPersonaJuridicaDTO.TC_Modificado_Por;
                    result.TB_Verificado = entidadPersonaJuridicaDTO.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEntidadPersonaJuridica(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona_Juridica.SingleOrDefault(b => b.TN_ID_Icono_Persona_Juridica == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadPersonaJuridicaDTO> ListarEntidadPersonaJuridicas()
        {
            List<TMCCM_EntidadPersonaJuridicaDTO> entidadPersonaJuridicaDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadPersonaJuridicaDTO = context.TMCCM_Entidad_Persona_Juridica.Where(c => c.TB_Eliminado == true)
                   .Select(personaJuridicaItem => new TMCCM_EntidadPersonaJuridicaDTO()
                   {
                       TN_ID_Persona_Juridica = personaJuridicaItem.TN_ID_Persona_Juridica,
                       TN_ID_Caso = personaJuridicaItem.TN_ID_Caso,
                       TC_ID_Cedula_Juridica = personaJuridicaItem.TC_ID_Cedula_Juridica,
                       TC_Nombre_Organización = personaJuridicaItem.TC_Nombre_Organización,
                       TC_Nombre_Comercial = personaJuridicaItem.TC_Nombre_Comercial,
                       TN_ID_Icono_Persona_Juridica = personaJuridicaItem.TN_ID_Icono_Persona_Juridica,
                       imgTemporal = utilidades.ConvertToString64(personaJuridicaItem.TB_Fotografia),
                       TN_ID_Tipo_Organizacion = personaJuridicaItem.TN_ID_Tipo_Organizacion,
                       TC_Sitio_Web = personaJuridicaItem.TC_Sitio_Web,
                       TC_Comentario = personaJuridicaItem.TC_Comentario,
                       TF_Fecha_Creacion = personaJuridicaItem.TF_Fecha_Creacion,
                       TF_Fecha_Modificacion = personaJuridicaItem.TF_Fecha_Modificacion,
                       TC_Creado_Por = personaJuridicaItem.TC_Creado_Por,
                       TC_Modificado_Por = personaJuridicaItem.TC_Modificado_Por,
                       TB_Verificado = personaJuridicaItem.TB_Verificado
                   }).ToList < TMCCM_EntidadPersonaJuridicaDTO>();
            }

            return entidadPersonaJuridicaDTO;
        }

        public TMCCM_EntidadPersonaJuridicaDTO ObtenerEntidadPersonaJuridicaPorID(int ID)
        {
            TMCCM_EntidadPersonaJuridicaDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from personaJuridicaItem in context.TMCCM_Entidad_Persona_Juridica
                       select new TMCCM_EntidadPersonaJuridicaDTO()
                       {
                           TN_ID_Persona_Juridica = personaJuridicaItem.TN_ID_Persona_Juridica,
                           TN_ID_Caso = personaJuridicaItem.TN_ID_Caso,
                           TC_ID_Cedula_Juridica = personaJuridicaItem.TC_ID_Cedula_Juridica,
                           TC_Nombre_Organización = personaJuridicaItem.TC_Nombre_Organización,
                           TC_Nombre_Comercial = personaJuridicaItem.TC_Nombre_Comercial,
                           TN_ID_Icono_Persona_Juridica = personaJuridicaItem.TN_ID_Icono_Persona_Juridica,
                           imgTemporal = utilidades.ConvertToString64(personaJuridicaItem.TB_Fotografia),
                           TN_ID_Tipo_Organizacion = personaJuridicaItem.TN_ID_Tipo_Organizacion,
                           TC_Sitio_Web = personaJuridicaItem.TC_Sitio_Web,
                           TC_Comentario = personaJuridicaItem.TC_Comentario,
                           TF_Fecha_Creacion = personaJuridicaItem.TF_Fecha_Creacion,
                           TF_Fecha_Modificacion = personaJuridicaItem.TF_Fecha_Modificacion,
                           TC_Creado_Por = personaJuridicaItem.TC_Creado_Por,
                           TC_Modificado_Por = personaJuridicaItem.TC_Modificado_Por,
                           TB_Verificado = personaJuridicaItem.TB_Verificado
                       }).Where(x => x.TN_ID_Persona_Juridica == ID).Single();
            }
            return aux;
        }


    }
}
