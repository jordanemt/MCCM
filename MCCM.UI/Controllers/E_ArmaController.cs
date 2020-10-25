using MCCM.Entidad.DTO;
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
        public String Insertar_E_Arma(TMCCM_Entidad_Arma entidadArma)
        {
            entidadArmaNegocio.InsertarEntidadArma(entidadArma);
            return "S";
        }
        public String Listar_E_Arma(int caso)
        {
            return JsonConvert.SerializeObject(entidadArmaNegocio.ListarEntidadArmas(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_ArmaPorID(int entidadArmaID)
        {
            return entidadArmaNegocio.EliminarEntidadArma(entidadArmaID);
        }
        [HttpPost]
        public String Modificar_E_Arma(TMCCM_Entidad_Arma entidadArma)
        {
            entidadArmaNegocio.ActualizarEntidadArma(entidadArma);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_ArmaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadArmaNegocio.ObtenerEntidadArmaPorID(ID), Formatting.Indented);
        }

    }
}