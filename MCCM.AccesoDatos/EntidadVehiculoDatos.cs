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
    public class EntidadVehiculoDatos
    {
        Utilidades utilidades = new Utilidades();
        public void InsertarEntidadVehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            using (var context = new MCCMEntities())
            {
                context.TMCCM_Entidad_Vehiculo.Add(new TMCCM_Entidad_Vehiculo()
                {
                    TN_ID_Caso = entidadVehiculoDTO.TN_ID_Caso,
                    TN_ID_Marca_Vehiculo = entidadVehiculoDTO.TN_ID_Marca_Vehiculo,

                    TN_ID_Color_Vehiculo = entidadVehiculoDTO.TN_ID_Color_Vehiculo,
                    TC_Placa = entidadVehiculoDTO.TC_Placa,
                    TC_Estilo = entidadVehiculoDTO.TC_Estilo,
                    TN_Anno = entidadVehiculoDTO.TN_Anno,
                    TB_Fotografia = utilidades.ConverToBytes(entidadVehiculoDTO.TB_Fotografia),
                    TC_Comentario = entidadVehiculoDTO.TC_Comentario,
                    TF_Fecha_Creacion = entidadVehiculoDTO.TF_Fecha_Creacion,
                    TF_Fecha_Modificacion = entidadVehiculoDTO.TF_Fecha_Modificacion,
                    TC_Creado_Por = entidadVehiculoDTO.TC_Creado_Por,
                    TC_Modificado_Por = "",
                    TB_Verificado = entidadVehiculoDTO.TB_Verificado,
                });

                context.SaveChanges();
            }
        }
        public void ActualizarEntidadVehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Vehiculo.SingleOrDefault(b => b.TN_ID_Vehiculo == entidadVehiculoDTO.TN_ID_Vehiculo);
                if (result != null)
                {
                    result.TN_ID_Vehiculo = entidadVehiculoDTO.TN_ID_Vehiculo;
                    result.TN_ID_Caso = entidadVehiculoDTO.TN_ID_Caso;
                    result.TN_ID_Marca_Vehiculo = entidadVehiculoDTO.TN_ID_Marca_Vehiculo;
                    result.TN_ID_Color_Vehiculo = entidadVehiculoDTO.TN_ID_Color_Vehiculo;
                    result.TC_Placa = entidadVehiculoDTO.TC_Placa;
                    result.TC_Estilo = entidadVehiculoDTO.TC_Estilo;
                    result.TN_Anno = entidadVehiculoDTO.TN_Anno;
                    result.TB_Fotografia = utilidades.ConverToBytes(entidadVehiculoDTO.TB_Fotografia);
                    result.TC_Comentario = entidadVehiculoDTO.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadVehiculoDTO.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadVehiculoDTO.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadVehiculoDTO.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadVehiculoDTO.TC_Modificado_Por;
                    result.TB_Verificado = entidadVehiculoDTO.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEntidadVehiculo(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Persona.SingleOrDefault(b => b.TN_ID_Persona == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadVehiculoDTO> ListarEntidadVehiculos( int caso)
        {
            List<TMCCM_EntidadVehiculoDTO> entidadVehiculoDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadVehiculoDTO = context.TMCCM_Entidad_Vehiculo.Where(c => c.TB_Eliminado == false && c.TN_ID_Caso == caso)
                   .Select(vehiculoItem => new TMCCM_EntidadVehiculoDTO()
                   {
                       TN_ID_Vehiculo = vehiculoItem.TN_ID_Vehiculo,
                       TN_ID_Caso = vehiculoItem.TN_ID_Caso,
                       TN_ID_Marca_Vehiculo = vehiculoItem.TN_ID_Marca_Vehiculo,
                
                       TN_ID_Color_Vehiculo = vehiculoItem.TN_ID_Color_Vehiculo,
                       TC_Placa = vehiculoItem.TC_Placa,
                       TC_Estilo = vehiculoItem.TC_Estilo,
                       TN_Anno = vehiculoItem.TN_Anno,
                       imgTemporal = utilidades.ConvertToString64(vehiculoItem.TB_Fotografia),
                       TC_Comentario = vehiculoItem.TC_Comentario,
                       TF_Fecha_Creacion = vehiculoItem.TF_Fecha_Creacion,
                       TF_Fecha_Modificacion = vehiculoItem.TF_Fecha_Modificacion,
                       TC_Creado_Por = vehiculoItem.TC_Creado_Por,
                       TC_Modificado_Por = vehiculoItem.TC_Modificado_Por,
                       TB_Verificado = vehiculoItem.TB_Verificado,
                   }).ToList<TMCCM_EntidadVehiculoDTO>();
            }

            return entidadVehiculoDTO;
        }

        public TMCCM_EntidadVehiculoDTO ObtenerEntidadVehiculoPorID(int ID)
        {
            TMCCM_EntidadVehiculoDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from vehiculoItem in context.TMCCM_Entidad_Vehiculo
                       select new TMCCM_EntidadVehiculoDTO()
                       {
                           TN_ID_Vehiculo = vehiculoItem.TN_ID_Vehiculo,
                           TN_ID_Caso = vehiculoItem.TN_ID_Caso,
                           TN_ID_Marca_Vehiculo = vehiculoItem.TN_ID_Marca_Vehiculo,
                       
                           TN_ID_Color_Vehiculo = vehiculoItem.TN_ID_Color_Vehiculo,
                           TC_Placa = vehiculoItem.TC_Placa,
                           TC_Estilo = vehiculoItem.TC_Estilo,
                           TN_Anno = vehiculoItem.TN_Anno,
                           imgTemporal = utilidades.ConvertToString64(vehiculoItem.TB_Fotografia),
                           TC_Comentario = vehiculoItem.TC_Comentario,
                           TF_Fecha_Creacion = vehiculoItem.TF_Fecha_Creacion,
                           TF_Fecha_Modificacion = vehiculoItem.TF_Fecha_Modificacion,
                           TC_Creado_Por = vehiculoItem.TC_Creado_Por,
                           TC_Modificado_Por = vehiculoItem.TC_Modificado_Por,
                           TB_Verificado = vehiculoItem.TB_Verificado
                       }).Where(x => x.TN_ID_Vehiculo == ID).Single();
            }
            return aux;
        }
    }
}
