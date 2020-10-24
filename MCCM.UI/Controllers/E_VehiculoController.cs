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
        // GET: E_Vehiculo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Insertar_E_Vehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            //return Path.GetFileNameWithoutExtension(entidadPersonaDTO.TB_Fotografia.FileName); 

            entidadVehiculoNegocio.InsertarEntidadVehiculo(entidadVehiculoDTO);
            return "S";
        }
    }
}