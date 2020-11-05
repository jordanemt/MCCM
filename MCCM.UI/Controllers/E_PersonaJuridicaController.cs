using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
using System.IO;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class E_PersonaJuridicaController : Controller
    {
        EntidadPersonaJuridicaNegocio entidadPersonaJuridicaNegocio = new EntidadPersonaJuridicaNegocio();

        [HttpPost]
        public String Insertar_E_PersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica, int caso)
        {
            entidadPersonaJuridica.TN_ID_Caso = caso;
            entidadPersonaJuridicaNegocio.InsertarEntidadPersonaJuridica(entidadPersonaJuridica);
            return "S";
        }
        [HttpGet]
        public String Listar_E_PersonaJuridica(int caso)
        {

            return entidadPersonaJuridicaNegocio.ListarEntidadPersonaJuridicas(caso);
        }
        [HttpPost]
        public String Eliminar_E_PersonaJuridicaPorID(int entidadPersonaJuridicaID)
        {
            return entidadPersonaJuridicaNegocio.EliminarEntidadPersonaJuridica(entidadPersonaJuridicaID);
        }
        [HttpPost]
        public String Modificar_E_PersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica, int caso)
        {

            entidadPersonaJuridicaNegocio.ActualizarEntidadPersonaJuridica(entidadPersonaJuridica);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_PersonaJuridicaPorID(int ID)
        {
            return entidadPersonaJuridicaNegocio.ObtenerEntidadPersonaJuridicaPorID(ID);
        }
    }
}