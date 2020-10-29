using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System.IO;
using MCCM.ReglasNegocio;


namespace MCCM.UI.Controllers
{
    public class E_VehiculoController : Controller
    {
        EntidadVehiculoNegocio entidadVehiculoNegocio = new EntidadVehiculoNegocio();

        [HttpPost]
        public String Insertar_E_Vehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            entidadVehiculoNegocio.InsertarEntidadVehiculo(entidadVehiculoDTO);
            return "S";
        }
        [HttpGet]
        public String Listar_E_Vehiculo(int caso)
        {
            return JsonConvert.SerializeObject(entidadVehiculoNegocio.ListarEntidadVehiculo(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_VehiculoPorID(int entidadVehiculoID)
        {
            return entidadVehiculoNegocio.EliminarEntidadVehiculo(entidadVehiculoID);
        }
        [HttpPost]
        public String Modificar_E_Vehiculo(TMCCM_EntidadVehiculoDTO entidadDrogaDTO)
        {
            entidadVehiculoNegocio.ActualizarEntidadVehiculo(entidadDrogaDTO);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_DrogaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadVehiculoNegocio.ObtenerEntidadVehiculoPorID(ID), Formatting.Indented);
        }
    }
}