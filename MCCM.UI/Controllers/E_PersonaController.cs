using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System.IO;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class E_PersonaController : Controller
    {

        EntidadPersonaNegocio entidadPersonaNegocio = new EntidadPersonaNegocio();

        [HttpPost]
        public String Insertar_E_Persona(TMCCM_Entidad_Persona entidadPersonaDTO)
        {

            entidadPersonaNegocio.InsertarEntidadPersona(entidadPersonaDTO);
            return "S";
        }
        [HttpGet]
        public String Listar_E_Persona(int caso)
        {
            return JsonConvert.SerializeObject(entidadPersonaNegocio.ListarEntidadPersonas(caso), Formatting.Indented);
        }
        [HttpDelete]
        public String Eliminar_E_PersonaPorID(int entidadPersonaID)
        {
            return entidadPersonaNegocio.EliminarEntidadPersona(entidadPersonaID);
        }
        [HttpPost]
        public String Modificar_E_Persona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            entidadPersonaNegocio.ActualizarEntidadPersona(entidadPersonaDTO);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_PersonaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadPersonaNegocio.ObtenerEntidadPersonaPorID(ID), Formatting.Indented);
        }

    }
}






