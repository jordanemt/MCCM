using MCCM.Entidad;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class EntidadPersonaDatos
    {

        public void InsertarEntidadPersona(TMCCM_Entidad_Persona entidadPersona)
        {


            using (var context = new MCCMEntities())
            {
                entidadPersona.TB_Eliminado = false;
                entidadPersona.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_Entidad_Persona.Add(entidadPersona);
                context.SaveChanges();
            }

        }

        public void ActualizarEntidadPersona(TMCCM_Entidad_Persona entidadPersona)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona.SingleOrDefault(b => b.TN_ID_Persona == entidadPersona.TN_ID_Persona);
                if (result != null)
                {
                    result.TN_ID_Persona = entidadPersona.TN_ID_Persona;
                    result.TN_ID_Tipo_Identificacion = entidadPersona.TN_ID_Tipo_Identificacion;
                    result.TN_ID_Sexo = entidadPersona.TN_ID_Sexo;
                    result.TN_ID_Genero = entidadPersona.TN_ID_Genero;
                    result.TN_ID_Nacionalidad = entidadPersona.TN_ID_Nacionalidad;
                    result.TC_Nombre = entidadPersona.TC_Nombre;
                    result.TC_Primer_Apellido = entidadPersona.TC_Primer_Apellido;
                    result.TC_Segundo_Apellido = entidadPersona.TC_Segundo_Apellido;
                    result.TF_Fecha_Nacimiento = entidadPersona.TF_Fecha_Nacimiento;
                    result.TN_Edad = entidadPersona.TN_Edad;
                    result.TB_Fotografia = entidadPersona.TB_Fotografia;
                    result.TC_Cedula = entidadPersona.TC_Cedula;
                    result.TB_Fallecido = entidadPersona.TB_Fallecido;
                    result.TN_Autopsia = entidadPersona.TN_Autopsia;
                    result.TB_Exp_Criminal = entidadPersona.TB_Exp_Criminal;
                    result.TF_Fecha_Creacion = entidadPersona.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = DateTime.Now;
                    result.TC_Creado_Por = entidadPersona.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadPersona.TC_Modificado_Por;
                    result.TB_Verificado = entidadPersona.TB_Verificado;
                    result.TC_Comentario = entidadPersona.TC_Comentario;
                    result.TC_Alias = entidadPersona.TC_Alias;
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

        public string ListarEntidadPersonas(int caso)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from item in
                              (from personaItem in context.TMCCM_Entidad_Persona
                               from nacionalidadItem in context.TMCCM_C_Persona_Nacionalidad
                               from generoItem in context.TMCCM_C_Persona_Genero
                               where personaItem.TB_Eliminado == false
                               where personaItem.TN_ID_Caso == caso
                               where personaItem.TN_ID_Nacionalidad == nacionalidadItem.TN_ID_Nacionalidad
                               where personaItem.TN_ID_Genero == generoItem.TN_ID_Genero
                               select new

                               {
                                   TN_ID_Persona = personaItem.TN_ID_Persona,
                                   TC_Genero = generoItem.TC_Descripcion,
                                   TC_Nacionalidad = nacionalidadItem.TC_Descripcion,
                                   TC_Nombre = personaItem.TC_Nombre,
                                   TB_Imagen = personaItem.TB_Fotografia,
                                   TC_Cedula = personaItem.TC_Cedula,
                                   TB_Exp_Criminal = personaItem.TB_Exp_Criminal,
                                   TC_Alias = personaItem.TC_Alias
                               }).AsEnumerable()

                               select new
                               {
                                   TN_ID_Persona = item.TN_ID_Persona,
                                   TC_Genero = item.TC_Genero,
                                   TC_Nacionalidad = item.TC_Nacionalidad,
                                   TC_Nombre = item.TC_Nombre,
                                   TC_Imagen = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(item.TB_Imagen)),
                                   TC_Cedula = item.TC_Cedula,
                                   TB_Exp_Criminal = item.TB_Exp_Criminal,
                                   TC_Alias = item.TC_Alias
                               });

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

        public string ObtenerEntidadPersonaPorID(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from personaItem in context.TMCCM_Entidad_Persona
                               where personaItem.TB_Eliminado == false
                               where personaItem.TN_ID_Persona == ID
                               select new
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
                                   TB_Fotografia = personaItem.TB_Fotografia,
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
                               }).Single();
                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
        public string Conversor_Binario_String64(byte[] image)
        {

            string imreBase64Data = Convert.ToBase64String(image);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
    }
}

