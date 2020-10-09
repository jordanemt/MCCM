using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System.Data.Entity;


namespace MCCM.AccesoDatos
{
    public class EntidadTelefonoDatos
    {
        Utilidades utilidades = new Utilidades();
        public void InsertarEntidadTelefono(TMCCM_EntidadTelefonoDTO entidadTelefonoDTO)
        {
            using (var context = new MCCMEntities())
            {
                context.TMCCM_Entidad_Telefono.Add(new TMCCM_Entidad_Telefono()
                {
                    TN_ID_Caso = entidadTelefonoDTO.TN_ID_Caso,
                    TN_ID_Proveedor = entidadTelefonoDTO.TN_ID_Proveedor,
                    TN_ID_Icono_Telefono = entidadTelefonoDTO.TN_ID_Icono_Telefono,
                    TN_Numero = entidadTelefonoDTO.TN_Numero,
                    TC_Comentario = entidadTelefonoDTO.TC_Comentario,
                    TF_Fecha_Creacion = entidadTelefonoDTO.TF_Fecha_Creacion,
                    TF_Fecha_Modificacion = entidadTelefonoDTO.TF_Fecha_Modificacion,
                    TC_Creado_Por = entidadTelefonoDTO.TC_Creado_Por,
                    TC_Modificado_Por = "",
                    TB_Verificado = entidadTelefonoDTO.TB_Verificado,
                });

                context.SaveChanges();
            }
        }
        public void ActualizarEntidadTelefono(TMCCM_EntidadTelefonoDTO entidadTelefonoDTO)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Telefono.SingleOrDefault(b => b.TN_ID_Telefono == entidadTelefonoDTO.TN_ID_Telefono);
                if (result != null)
                {
                    result.TN_ID_Telefono = entidadTelefonoDTO.TN_ID_Telefono;
                    result.TN_ID_Caso = entidadTelefonoDTO.TN_ID_Caso;
                    result.TN_ID_Proveedor = entidadTelefonoDTO.TN_ID_Proveedor;
                    result.TN_ID_Icono_Telefono = entidadTelefonoDTO.TN_ID_Icono_Telefono;
                    result.TN_Numero = entidadTelefonoDTO.TN_Numero;
                    result.TC_Comentario = entidadTelefonoDTO.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadTelefonoDTO.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadTelefonoDTO.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadTelefonoDTO.TC_Creado_Por;
                    result.TC_Modificado_Por = "";
                    result.TB_Verificado = entidadTelefonoDTO.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEntidadTelefono(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Telefono.SingleOrDefault(b => b.TN_ID_Telefono == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadTelefonoDTO> ListarEntidadTelefonos()
        {
            List<TMCCM_EntidadTelefonoDTO> entidadTelefonoDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadTelefonoDTO = context.TMCCM_Entidad_Telefono.Where(c => c.TB_Eliminado == true)
                   .Select(telefonoItem => new TMCCM_EntidadTelefonoDTO()
                   {
                       TN_ID_Telefono = telefonoItem.TN_ID_Telefono,
                       TN_ID_Caso = telefonoItem.TN_ID_Caso,
                       TN_ID_Proveedor = telefonoItem.TN_ID_Proveedor,
                       TN_ID_Icono_Telefono = telefonoItem.TN_ID_Icono_Telefono,
                       TN_Numero = telefonoItem.TN_Numero,
                       TC_Comentario = telefonoItem.TC_Comentario,
                       TF_Fecha_Creacion = telefonoItem.TF_Fecha_Creacion,
                       TF_Fecha_Modificacion = telefonoItem.TF_Fecha_Modificacion,
                       TC_Creado_Por = telefonoItem.TC_Creado_Por,
                       TC_Modificado_Por = telefonoItem.TC_Modificado_Por,
                       TB_Verificado = telefonoItem.TB_Verificado,
                   }).ToList<TMCCM_EntidadTelefonoDTO>();
            }
            return entidadTelefonoDTO;
        }

        public TMCCM_EntidadTelefonoDTO ObtenerEntidadTelefonoPorID(int ID)
        {
            TMCCM_EntidadTelefonoDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from telefonoItem in context.TMCCM_Entidad_Telefono
                       select new TMCCM_EntidadTelefonoDTO()
                       {
                           TN_ID_Telefono = telefonoItem.TN_ID_Telefono,
                           TN_ID_Caso = telefonoItem.TN_ID_Caso,
                           TN_ID_Proveedor = telefonoItem.TN_ID_Proveedor,
                           TN_ID_Icono_Telefono = telefonoItem.TN_ID_Icono_Telefono,
                           TN_Numero = telefonoItem.TN_Numero,
                           TC_Comentario = telefonoItem.TC_Comentario,
                           TF_Fecha_Creacion = telefonoItem.TF_Fecha_Creacion,
                           TF_Fecha_Modificacion = telefonoItem.TF_Fecha_Modificacion,
                           TC_Creado_Por = telefonoItem.TC_Creado_Por,
                           TC_Modificado_Por = telefonoItem.TC_Modificado_Por,
                           TB_Verificado = telefonoItem.TB_Verificado,
                       }).Where(x => x.TN_ID_Telefono == ID).Single();
            }
            return aux;
        }
    }

}

