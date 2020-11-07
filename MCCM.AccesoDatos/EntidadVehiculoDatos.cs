using MCCM.AccesoDatos.exceptions;
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
    public class EntidadVehiculoDatos
    {
        public void InsertarEntidadVehiculo(TMCCM_Entidad_Vehiculo entidadVehiculo)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                entidadVehiculo.TB_Eliminado = false;
                entidadVehiculo.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_Entidad_Vehiculo.Add(entidadVehiculo);
                context.SaveChanges();
            }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }

        }
        public void ActualizarEntidadVehiculo(TMCCM_Entidad_Vehiculo entidadVehiculo)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Vehiculo.SingleOrDefault(b => b.TN_ID_Vehiculo == entidadVehiculo.TN_ID_Vehiculo);
                if (result != null)
                {
                    result.TN_ID_Vehiculo = entidadVehiculo.TN_ID_Vehiculo;
                    result.TN_ID_Marca_Vehiculo = entidadVehiculo.TN_ID_Marca_Vehiculo;
                    result.TN_ID_Color_Vehiculo = entidadVehiculo.TN_ID_Color_Vehiculo;
                    result.TC_Placa = entidadVehiculo.TC_Placa;
                    result.TN_ID_Clase_Vehiculo = entidadVehiculo.TN_ID_Clase_Vehiculo;
                    result.TC_Estilo = entidadVehiculo.TC_Estilo;
                    result.TN_Anno = entidadVehiculo.TN_Anno;
                    result.TB_Fotografia = entidadVehiculo.TB_Fotografia;
                    result.TC_Comentario = entidadVehiculo.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadVehiculo.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = DateTime.Now;
                    result.TC_Creado_Por = entidadVehiculo.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadVehiculo.TC_Modificado_Por;
                    result.TB_Verificado = entidadVehiculo.TB_Verificado;
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

        public void EliminarEntidadVehiculo(int ID)
        {
            try { 
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Vehiculo.SingleOrDefault(b => b.TN_ID_Vehiculo == ID);
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

        public string ListarEntidadVehiculos(int caso)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from item in
                               (from vehiculoItem in context.TMCCM_Entidad_Vehiculo
                                from marcaItem in context.TMCCM_C_Vehiculo_Marca
                                where vehiculoItem.TB_Eliminado == false
                                where vehiculoItem.TN_ID_Caso == caso
                                where vehiculoItem.TN_ID_Marca_Vehiculo == marcaItem.TN_ID_Marca_Vehiculo
                                select new
                                {
                                    TN_ID_Vehiculo = vehiculoItem.TN_ID_Vehiculo,
                                    TC_Marca = marcaItem.TC_Descripcion,
                                    TC_Placa = vehiculoItem.TC_Placa,
                                    TC_Estilo = vehiculoItem.TC_Estilo,
                                    TB_Imagen = vehiculoItem.TB_Fotografia
                                }).AsEnumerable()
                               select new
                               {

                                   TN_ID_Vehiculo = item.TN_ID_Vehiculo,
                                   TC_Marca = item.TC_Marca,
                                   TC_Placa = item.TC_Placa,
                                   TC_Estilo = item.TC_Estilo,
                                   TC_Imagen = Conversor_Binario_String64(item.TB_Imagen)

                                   //string.Format("data:image/png;base64,{0}", Convert.ToBase64String(item.TB_Imagen))
                               });


                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }

        public string ObtenerEntidadVehiculoPorID(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo = (from vehiculoItem in context.TMCCM_Entidad_Vehiculo
                               where vehiculoItem.TB_Eliminado == false
                               where vehiculoItem.TN_ID_Vehiculo == ID
                               select new
                               {
                                   TN_ID_Vehiculo = vehiculoItem.TN_ID_Vehiculo,
                                   TN_ID_Caso = vehiculoItem.TN_ID_Caso,
                                   TN_ID_Marca_Vehiculo = vehiculoItem.TN_ID_Marca_Vehiculo,
                                   TN_ID_Color_Vehiculo = vehiculoItem.TN_ID_Color_Vehiculo,
                                   TC_Placa = vehiculoItem.TC_Placa,
                                   TN_ID_Clase_Vehiculo = vehiculoItem.TN_ID_Clase_Vehiculo,
                                   TC_Estilo = vehiculoItem.TC_Estilo,
                                   TN_Anno = vehiculoItem.TN_Anno,
                                   TB_Fotografia = vehiculoItem.TB_Fotografia,
                                   TC_Comentario = vehiculoItem.TC_Comentario,
                                   TF_Fecha_Creacion = vehiculoItem.TF_Fecha_Creacion,
                                   TF_Fecha_Modificacion = vehiculoItem.TF_Fecha_Modificacion,
                                   TC_Creado_Por = vehiculoItem.TC_Creado_Por,
                                   TC_Modificado_Por = vehiculoItem.TC_Modificado_Por,
                                   TB_Verificado = vehiculoItem.TB_Verificado
                               }).Single();

                return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }


        public string Conversor_Binario_String64(byte[] image)
        {
            if (image != null) 
            {  string imreBase64Data = Convert.ToBase64String(image);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;}

            return null;
        
        }
    }
}
