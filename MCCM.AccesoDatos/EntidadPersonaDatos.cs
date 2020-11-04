using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MCCM.AccesoDatos
{
    public class EntidadPersonaDatos
    {
        Utilidades utilidades = new Utilidades();


      
        public void InsertarEntidadPersona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            using (var context = new MCCMEntities())
            {
                
                    context.TMCCM_Entidad_Persona.Add(new TMCCM_Entidad_Persona()
                    {
                        TN_ID_Caso = entidadPersonaDTO.TN_ID_Caso,
                        TN_ID_Tipo_Identificacion = entidadPersonaDTO.TN_ID_Tipo_Identificacion,
                        TN_ID_Sexo = entidadPersonaDTO.TN_ID_Sexo,
                        TN_ID_Genero = entidadPersonaDTO.TN_ID_Genero,
                        TN_ID_Nacionalidad = entidadPersonaDTO.TN_ID_Nacionalidad,
                        TC_Nombre = entidadPersonaDTO.TC_Nombre,
                        TC_Primer_Apellido = entidadPersonaDTO.TC_Primer_Apellido,
                        TC_Segundo_Apellido = entidadPersonaDTO.TC_Segundo_Apellido,
                        TF_Fecha_Nacimiento = entidadPersonaDTO.TF_Fecha_Nacimiento,
                        TN_Edad = entidadPersonaDTO.TN_Edad,
                        TB_Fotografia = entidadPersonaDTO.imgTemporal,
                        TC_Cedula = entidadPersonaDTO.TC_Cedula,
                        TB_Fallecido = entidadPersonaDTO.TB_Fallecido,
                        TN_Autopsia = entidadPersonaDTO.TN_Autopsia,
                        TB_Exp_Criminal = entidadPersonaDTO.TB_Exp_Criminal,
                        TC_Alias = entidadPersonaDTO.TC_Alias,
                        TC_Creado_Por = entidadPersonaDTO.TC_Creado_Por,
                        TC_Comentario = entidadPersonaDTO.TC_Comentario,
                        TB_Verificado = entidadPersonaDTO.TB_Verificado,
                        TF_Fecha_Creacion = DateTime.Now,
                        TB_Eliminado = false

                    });
                    context.SaveChanges();
                }
        }

        public void Insertar(TMCCM_Entidad_Persona entidadPersona)
        {
            using (var context = new MCCMEntities())
            {
                entidadPersona.TB_Eliminado = false;
                entidadPersona.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_Entidad_Persona.Add(entidadPersona);
                context.SaveChanges();

            }

        }





        public void ActualizarEntidadPersona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
            {
                using (var context = new MCCMEntities())
                {
                    var result = context.TMCCM_Entidad_Persona.SingleOrDefault(b => b.TN_ID_Persona == entidadPersonaDTO.TN_ID_Persona);
                if (result != null)
                {
                    result.TN_ID_Persona = entidadPersonaDTO.TN_ID_Persona;
                        result.TN_ID_Tipo_Identificacion = entidadPersonaDTO.TN_ID_Tipo_Identificacion;
                        result.TN_ID_Sexo = entidadPersonaDTO.TN_ID_Sexo;
                        result.TN_ID_Genero = entidadPersonaDTO.TN_ID_Genero;
                        result.TN_ID_Nacionalidad = entidadPersonaDTO.TN_ID_Nacionalidad;
                        result.TC_Nombre = entidadPersonaDTO.TC_Nombre;
                        result.TC_Primer_Apellido = entidadPersonaDTO.TC_Primer_Apellido;
                        result.TC_Segundo_Apellido = entidadPersonaDTO.TC_Segundo_Apellido;
                        result.TF_Fecha_Nacimiento = entidadPersonaDTO.TF_Fecha_Nacimiento;
                        result.TN_Edad = entidadPersonaDTO.TN_Edad;
                        result.TB_Fotografia = entidadPersonaDTO.imgTemporal;
                        result.TC_Cedula = entidadPersonaDTO.TC_Cedula;
                        result.TB_Fallecido = entidadPersonaDTO.TB_Fallecido;
                        result.TN_Autopsia = entidadPersonaDTO.TN_Autopsia;
                        result.TB_Exp_Criminal = entidadPersonaDTO.TB_Exp_Criminal;
                        result.TF_Fecha_Creacion = entidadPersonaDTO.TF_Fecha_Creacion;
                        result.TF_Fecha_Modificacion = entidadPersonaDTO.TF_Fecha_Modificacion;
                        result.TC_Creado_Por = entidadPersonaDTO.TC_Creado_Por;
                        result.TC_Modificado_Por = entidadPersonaDTO.TC_Modificado_Por;
                        result.TB_Verificado = entidadPersonaDTO.TB_Verificado;
                        result.TC_Comentario = entidadPersonaDTO.TC_Comentario;
                        result.TC_Alias = entidadPersonaDTO.TC_Alias;
                        context.Entry(result).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }

            public void EliminarEntidadPersona(int ID)
            {
                using (var context = new MCCMEntities())
                {
                    var result = context.TMCCM_Entidad_Persona.SingleOrDefault(b => b.TN_ID_Persona == ID);
                    if (result != null)
                    {
                        result.TB_Eliminado = true;
                        context.Entry(result).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }

            public List<TMCCM_EntidadPersonaDTO> ListarEntidadPersonas(int caso)
            {
                List<TMCCM_EntidadPersonaDTO> entidadPersonaDTO = null;

                using (var context = new MCCMEntities())
                {
                   entidadPersonaDTO = context.TMCCM_Entidad_Persona.Where(c => c.TB_Eliminado == false && c.TN_ID_Caso == caso)
                      .Select(personaItem => new TMCCM_EntidadPersonaDTO()
                      {
                          TN_ID_Persona = personaItem.TN_ID_Persona,
                          TN_ID_Caso = personaItem.TN_ID_Caso,
                          TN_ID_Tipo_Identificacion = personaItem.TN_ID_Tipo_Identificacion,
                          TN_ID_Sexo = personaItem.TN_ID_Sexo,
                          TN_ID_Genero = personaItem.TN_ID_Genero,
                          TN_ID_Nacionalidad = personaItem.TN_ID_Nacionalidad,
                          TC_Nombre = personaItem.TC_Nombre,
                          TC_Primer_Apellido = personaItem.TC_Primer_Apellido,
                          TC_Segundo_Apellido = personaItem.TC_Segundo_Apellido,
                          TF_Fecha_Nacimiento = personaItem.TF_Fecha_Nacimiento,
                          TN_Edad = personaItem.TN_Edad,
                          imgTemporal = personaItem.TB_Fotografia,
                          TC_Cedula = personaItem.TC_Cedula,
                          TB_Fallecido = personaItem.TB_Fallecido,
                          TN_Autopsia = personaItem.TN_Autopsia,
                          TB_Exp_Criminal = personaItem.TB_Exp_Criminal,
                          TF_Fecha_Creacion = personaItem.TF_Fecha_Creacion,
                          TF_Fecha_Modificacion = personaItem.TF_Fecha_Modificacion,
                          TC_Creado_Por = personaItem.TC_Creado_Por,
                          TC_Modificado_Por = personaItem.TC_Modificado_Por,
                          TB_Verificado = personaItem.TB_Verificado,
                          TC_Comentario = personaItem.TC_Comentario,
                          TC_Alias = personaItem.TC_Alias
                      }).ToList<TMCCM_EntidadPersonaDTO>();
                }

                return entidadPersonaDTO;
            }

            public TMCCM_EntidadPersonaDTO ObtenerEntidadPersonaPorID(int ID)
            {
                TMCCM_EntidadPersonaDTO aux;
                using (var context = new MCCMEntities())
                {
                    aux = (from personaItem in context.TMCCM_Entidad_Persona
                           select new TMCCM_EntidadPersonaDTO()
                           {
                               TN_ID_Persona = personaItem.TN_ID_Persona,
                               TN_ID_Caso = personaItem.TN_ID_Caso,
                               TN_ID_Tipo_Identificacion = personaItem.TN_ID_Tipo_Identificacion,
                               TN_ID_Sexo = personaItem.TN_ID_Sexo,
                               TN_ID_Genero = personaItem.TN_ID_Genero,
                               TN_ID_Nacionalidad = personaItem.TN_ID_Nacionalidad,
                               TC_Nombre = personaItem.TC_Nombre,
                               TC_Primer_Apellido = personaItem.TC_Primer_Apellido,
                               TC_Segundo_Apellido = personaItem.TC_Segundo_Apellido,
                               TF_Fecha_Nacimiento = personaItem.TF_Fecha_Nacimiento,
                               TN_Edad = personaItem.TN_Edad,
                               imgTemporal = personaItem.TB_Fotografia,
                               TC_Cedula = personaItem.TC_Cedula,
                               TB_Fallecido = personaItem.TB_Fallecido,
                               TN_Autopsia = personaItem.TN_Autopsia,
                               TB_Exp_Criminal = personaItem.TB_Exp_Criminal,
                               TF_Fecha_Creacion = personaItem.TF_Fecha_Creacion,
                               TF_Fecha_Modificacion = personaItem.TF_Fecha_Modificacion,
                               TC_Creado_Por = personaItem.TC_Creado_Por,
                               TC_Modificado_Por = personaItem.TC_Modificado_Por,
                               TB_Verificado = personaItem.TB_Verificado,
                               TC_Comentario = personaItem.TC_Comentario,
                               TC_Alias = personaItem.TC_Alias
                           }).Where(x => x.TN_ID_Persona == ID).Single();
                }
                return aux;
            }
        }
    }

