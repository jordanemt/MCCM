using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using System.Data.Entity;
using Newtonsoft.Json;
using MCCM.AccesoDatos.exceptions;

namespace MCCM.AccesoDatos
{
    public class EntidadTelefonoDatos
    {
        public void InsertarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefono)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    context.TMCCM_Entidad_Telefono.Add(new TMCCM_Entidad_Telefono()
                    {
                        TN_ID_Caso = entidadTelefono.TN_ID_Caso,
                        TN_ID_Proveedor = entidadTelefono.TN_ID_Proveedor,
                        TN_Numero = entidadTelefono.TN_Numero,
                        TC_Comentario = entidadTelefono.TC_Comentario,
                        TF_Fecha_Creacion = entidadTelefono.TF_Fecha_Creacion,
                        TF_Fecha_Modificacion = entidadTelefono.TF_Fecha_Modificacion,
                        TC_Creado_Por = entidadTelefono.TC_Creado_Por,
                        TC_Modificado_Por = "",
                        TB_Verificado = entidadTelefono.TB_Verificado,
                        TB_Eliminado = false
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }
        public void ActualizarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefonoDTO)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var result = context.TMCCM_Entidad_Telefono.SingleOrDefault(b => b.TN_ID_Telefono == entidadTelefonoDTO.TN_ID_Telefono);
                    if (result != null)
                    {
                        result.TN_ID_Telefono = (int)entidadTelefonoDTO.TN_ID_Telefono;
                        result.TN_ID_Proveedor = entidadTelefonoDTO.TN_ID_Proveedor;
                        result.TN_Numero = entidadTelefonoDTO.TN_Numero;
                        result.TC_Comentario = entidadTelefonoDTO.TC_Comentario;
                        result.TF_Fecha_Creacion = entidadTelefonoDTO.TF_Fecha_Creacion;
                        result.TF_Fecha_Modificacion = entidadTelefonoDTO.TF_Fecha_Modificacion;
                        result.TC_Creado_Por = entidadTelefonoDTO.TC_Creado_Por;
                        result.TC_Modificado_Por = entidadTelefonoDTO.TC_Modificado_Por;
                        result.TB_Verificado = entidadTelefonoDTO.TB_Verificado;
                        context.Entry(result).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void EliminarEntidadTelefono(int ID)
        {
            try
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
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public string ListarEntidadTelefonos(int caso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = from t in context.TMCCM_Entidad_Telefono
                                  from p in context.TMCCM_C_Telefono_Empresa_Telefonica
                                  where t.TB_Eliminado == false
                                  where t.TN_ID_Caso == caso
                                  where t.TN_ID_Proveedor == p.TN_ID_Proveedor
                                  select new
                                  {
                                      TN_ID_Telefono = t.TN_ID_Telefono,
                                      TN_Numero = t.TN_Numero,
                                      TC_Descripcion = p.TC_Descripcion,
                                      TC_Comentario = t.TC_Comentario
                                  };
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public string ObtenerEntidadTelefonoPorID(int ID)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = (from telefonoItem in context.TMCCM_Entidad_Telefono
                                   where telefonoItem.TB_Eliminado == false
                                   where telefonoItem.TN_ID_Telefono == ID
                                   select new
                                   {
                                       TN_ID_Telefono = telefonoItem.TN_ID_Telefono,
                                       TN_ID_Proveedor = telefonoItem.TN_ID_Proveedor,
                                       TN_Numero_Telefono = telefonoItem.TN_Numero,
                                       TC_Comentario_Telefono = telefonoItem.TC_Comentario,
                                       TF_Fecha_Creacion_Telefono = telefonoItem.TF_Fecha_Creacion,
                                       TF_Fecha_Modificacion_Telefono = telefonoItem.TF_Fecha_Modificacion,
                                       TC_Creado_Por_Telefono = telefonoItem.TC_Creado_Por,
                                       TC_Modificado_Por_Telefono = telefonoItem.TC_Modificado_Por,
                                       TB_Verificado_Telefono = telefonoItem.TB_Verificado,
                                   }).Single();
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void InsertarTelefonoProveedor(TMCCM_C_Telefono_Empresa_Telefonica proveedor)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    context.TMCCM_C_Telefono_Empresa_Telefonica.Add(new TMCCM_C_Telefono_Empresa_Telefonica()
                    {
                        TC_Descripcion = proveedor.TC_Descripcion,
                        TB_Eliminado = false
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public string ListarTelefonosProveedores()
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var anonimo = from t in context.TMCCM_C_Telefono_Empresa_Telefonica
                                  where t.TB_Eliminado == false
                                  select new
                                  {
                                      TN_ID_Proveedor = t.TN_ID_Proveedor,
                                      TC_Descripcion = t.TC_Descripcion
                                  };
                    return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

    }
}

