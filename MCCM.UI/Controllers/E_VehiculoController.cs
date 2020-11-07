using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class E_VehiculoController : Controller
    {
        EntidadVehiculoNegocio entidadVehiculoNegocio = new EntidadVehiculoNegocio();

        [HttpPost]
        public String Insertar_E_Vehiculo(TMCCM_Entidad_Vehiculo entidadVehiculo, HttpPostedFileBase imagenVehiculo)
        {
            try { 
            if(imagenVehiculo!= null) { 
            HttpPostedFileBase file = imagenVehiculo;
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            } 
            entidadVehiculo.TB_Fotografia = fileData;
           }
           
            entidadVehiculoNegocio.InsertarEntidadVehiculo(entidadVehiculo);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_Vehiculo(int caso)
        {
            try { 
            return entidadVehiculoNegocio.ListarEntidadVehiculo(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_VehiculoPorID(int entidadVehiculoID)
        {
            try { 
            return entidadVehiculoNegocio.EliminarEntidadVehiculo(entidadVehiculoID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_Vehiculo(TMCCM_Entidad_Vehiculo entidadVehiculo, HttpPostedFileBase imagenVehiculo)
        {
            try { 
            if (imagenVehiculo != null) { 
            HttpPostedFileBase file = imagenVehiculo;

            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            entidadVehiculo.TB_Fotografia = fileData;
            }
 
            entidadVehiculoNegocio.ActualizarEntidadVehiculo(entidadVehiculo);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_VehiculoPorID(int ID)
        {
            try { 
            return entidadVehiculoNegocio.ObtenerEntidadVehiculoPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}