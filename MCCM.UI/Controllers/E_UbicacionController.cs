using MCCM.Entidad;
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
        public String Insertar_E_Ubicacion(TMCCM_Entidad_Ubicacion entidadUbicacion, int caso)
        {
            try { 
            entidadUbicacion.TN_ID_Caso = caso;
            entidadUbicacionNegocio.InsertarEntidadUbicacion(entidadUbicacion);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_Ubicacion(int caso)
        {
            try { 
            return entidadUbicacionNegocio.ListarEntidadUbicaciones(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_UbicacionPorID(int entidadUbicacionID)
        {
            try { 
            return entidadUbicacionNegocio.EliminarEntidadUbicacion(entidadUbicacionID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_Ubicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            try { 
            entidadUbicacionNegocio.ActualizarEntidadUbicacion(entidadUbicacion);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_UbicacionPorID(int ID)
        {
            try { 
            return entidadUbicacionNegocio.ObtenerEntidadUbicacionPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}