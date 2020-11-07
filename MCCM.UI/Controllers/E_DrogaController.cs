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
    public class E_DrogaController : Controller
    {
        EntidadDrogaNegocio entidadDrogaNegocio = new EntidadDrogaNegocio();

        [HttpPost]
        public String Insertar_E_Droga(TMCCM_Entidad_Droga entidadDroga, int caso)
        {
            try
            {
                entidadDroga.TN_ID_Caso = caso;
                entidadDrogaNegocio.InsertarEntidadDroga(entidadDroga);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_Droga(int caso)
        {
            try
            {
                return entidadDrogaNegocio.ListarEntidadDrogas(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_DrogaPorID(int entidadDrogaID)
        {
            try
            {
                return entidadDrogaNegocio.EliminarEntidadDroga(entidadDrogaID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_Droga(TMCCM_Entidad_Droga entidadDroga)
        {
            try
            {
                entidadDrogaNegocio.ActualizarEntidadDroga(entidadDroga);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_DrogaPorID(int ID)
        {
            try
            {
                return entidadDrogaNegocio.ObtenerEntidadDrogaPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}