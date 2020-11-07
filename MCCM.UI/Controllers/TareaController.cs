using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;

namespace MCCM.UI.Controllers
{
    public class TareaController : Controller
    {

        TareaNegocio tareaNegocio = new TareaNegocio();

        [HttpPost]
        public String InsertarTarea(TMCCM_Tarea tarea, DateTime TF_Fecha, int caso)
        {
            try
            {
                tarea.TF_Fecha = TF_Fecha;
                tarea.TN_ID_Caso = caso;
                tareaNegocio.InsertarTarea(tarea);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String ModificarTarea(TMCCM_Tarea tarea, DateTime fecha)
        {
            try
            {
                tarea.TF_Fecha = fecha;
                tareaNegocio.ModificarTarea(tarea);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public String ListarTarea(int caso)
        {
            try
            {
                return tareaNegocio.ListarTarea(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string ObtenerTareaPorID(int ID)
        {
            try
            {
                return tareaNegocio.ObtenerTareaPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string ObtenerCatalogoUsuarios()
        {
            try
            {
                return tareaNegocio.ObtenerCatalogoUsuarios();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        [HttpPost]
        public string EliminarTareaPorID(int tareaID)
        {
            try
            {
                
                return tareaNegocio.EliminarTarea(tareaID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}