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
        public void InsertarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefono)
        {
            using (var context = new MCCMEntities())
            {
                context.TMCCM_Entidad_Telefono.Add(new TMCCM_Entidad_Telefono()
                {
                    TN_ID_Caso = entidadTelefono.TN_ID_Caso,
                    TN_ID_Proveedor = entidadTelefono.TN_ID_Proveedor,
                    TN_ID_Icono_Telefono = entidadTelefono.TN_ID_Icono_Telefono,
                    TN_Numero = entidadTelefono.TN_Numero,
                    TC_Comentario = entidadTelefono.TC_Comentario,
                    TF_Fecha_Creacion = entidadTelefono.TF_Fecha_Creacion,
                    TF_Fecha_Modificacion = entidadTelefono.TF_Fecha_Modificacion,
                    TC_Creado_Por = entidadTelefono.TC_Creado_Por,
                    TC_Modificado_Por = "",
                    TB_Verificado = entidadTelefono.TB_Verificado,
                    TB_Eliminado = false
                }) ;

                context.SaveChanges();
            }
        }
        public void ActualizarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefonoDTO)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Telefono.SingleOrDefault(b => b.TN_ID_Telefono == entidadTelefonoDTO.TN_ID_Telefono);
                if (result != null)
                {
                    result.TN_ID_Telefono = (int)entidadTelefonoDTO.TN_ID_Telefono;
                    result.TN_ID_Proveedor = entidadTelefonoDTO.TN_ID_Proveedor;
                    result.TN_ID_Icono_Telefono = entidadTelefonoDTO.TN_ID_Icono_Telefono;
                    result.TN_Numero = entidadTelefonoDTO.TN_Numero;
                    result.TC_Comentario = entidadTelefonoDTO.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadTelefonoDTO.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadTelefonoDTO.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadTelefonoDTO.TC_Creado_Por;
                    result.TC_Modificado_Por =entidadTelefonoDTO.TC_Modificado_Por;
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
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<sp_listarEntidadTelefono_Result> ListarEntidadTelefonos(int caso)
        {
            using (var context = new MCCMEntities())
            {
                return context.sp_listarEntidadTelefono(caso).ToList(); 
            }
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

                           TN_ID_Proveedor = telefonoItem.TN_ID_Proveedor,
                           TN_ID_Icono_Telefono = telefonoItem.TN_ID_Icono_Telefono,
                           TN_Numero_Telefono = telefonoItem.TN_Numero,
                           TC_Comentario_Telefono = telefonoItem.TC_Comentario,
                           TF_Fecha_Creacion_Telefono = telefonoItem.TF_Fecha_Creacion,
                           TF_Fecha_Modificacion_Telefono = telefonoItem.TF_Fecha_Modificacion,
                           TC_Creado_Por_Telefono = telefonoItem.TC_Creado_Por,
                           TC_Modificado_Por_Telefono = telefonoItem.TC_Modificado_Por,
                           TB_Verificado_Telefono = telefonoItem.TB_Verificado,
                       }).Where(x => x.TN_ID_Telefono == ID).Single();
            }
            return aux;
        }
    }

}

