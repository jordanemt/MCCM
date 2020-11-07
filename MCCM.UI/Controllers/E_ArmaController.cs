using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad;
using Newtonsoft.Json;

namespace MCCM.UI.Controllers
{
    public class E_ArmaController : Controller
    {
        EntidadArmaNegocio entidadArmaNegocio = new EntidadArmaNegocio();
       
     
        [HttpPost]
        public String Insertar_E_Arma(TMCCM_Entidad_Arma entidadArma,int caso)
        {
            try { 
            entidadArma.TN_ID_Caso = caso;
            entidadArmaNegocio.InsertarEntidadArma(entidadArma);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_Arma(int caso)
        {
            try { 
            return entidadArmaNegocio.ListarEntidadArmas(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_ArmaPorID(int entidadArmaID)
        {
            try { 
            return entidadArmaNegocio.EliminarEntidadArma(entidadArmaID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_Arma(TMCCM_Entidad_Arma entidadArma)
        {
            try { 
            entidadArmaNegocio.ActualizarEntidadArma(entidadArma);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_ArmaPorID(int ID)
        {
            try { 
            return entidadArmaNegocio.ObtenerEntidadArmaPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}