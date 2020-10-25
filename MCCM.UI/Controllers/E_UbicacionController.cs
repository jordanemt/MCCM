using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class E_UbicacionController : Controller
    {
        EntidadUbicacionNegocio entidadUbicacionNegocio = new EntidadUbicacionNegocio();
  
        [HttpPost]
        public String Insertar_E_Ubicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
         
            entidadUbicacionNegocio.InsertarEntidadUbicacion(entidadUbicacion);
            return "S";
        }
        [HttpGet]
        public String Listar_E_Ubicacion(int caso)
        {
            return JsonConvert.SerializeObject(entidadUbicacionNegocio.ListarEntidadUbicaciones(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_UbicacionPorID(int entidadUbicacionID)
        {
            return entidadUbicacionNegocio.EliminarEntidadUbicacion(entidadUbicacionID);
        }
        [HttpPost]
        public String Modificar_E_Ubicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            entidadUbicacionNegocio.ActualizarEntidadUbicacion(entidadUbicacion);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_UbicacionPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadUbicacionNegocio.ObtenerEntidadUbicacionPorID(ID), Formatting.Indented);
        }
    }
}