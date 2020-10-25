using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;

namespace MCCM.UI.Controllers
{
    public class E_PersonaJuridicaController : Controller
    {
        EntidadPersonaJuridicaNegocio entidadPersonaJuridicaNegocio = new EntidadPersonaJuridicaNegocio();
     
        [HttpPost]
        public String Insertar_E_PersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {

            entidadPersonaJuridicaNegocio.InsertarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
            return "S";
        }
        [HttpGet]
        public String Listar_E_PersonaJuridica(int caso)
        {
            return JsonConvert.SerializeObject(entidadPersonaJuridicaNegocio.ListarEntidadPersonaJuridicas(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_PersonaJuridicaPorID(int entidadPersonaJuridicaID)
        {
            return entidadPersonaJuridicaNegocio.EliminarEntidadPersonaJuridica(entidadPersonaJuridicaID);
        }
        [HttpPost]
        public String Modificar_E_PersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO   entidadDrogaDTO)
        {
            entidadPersonaJuridicaNegocio.ActualizarEntidadPersonaJuridica(entidadDrogaDTO);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_PersonaJuridicaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadPersonaJuridicaNegocio.ObtenerEntidadPersonaJuridicaPorID(ID), Formatting.Indented);
        }
    }
}