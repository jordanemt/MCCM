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
        public String Insertar_E_PersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            try
            {
                entidadPersonaJuridicaNegocio.InsertarEntidadPersonaJuridica(entidadPersonaJuridica);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_PersonaJuridica(int caso)
        {
            try
            {
                return entidadPersonaJuridicaNegocio.ListarEntidadPersonaJuridicas(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_PersonaJuridicaPorID(int entidadPersonaJuridicaID)
        {
            try {
                return entidadPersonaJuridicaNegocio.EliminarEntidadPersonaJuridica(entidadPersonaJuridicaID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_PersonaJuridica(TMCCM_Entidad_Persona_Juridica entidadPersonaJuridica)
        {
            try
            {
                entidadPersonaJuridicaNegocio.ModificarEntidadPersonaJuridica(entidadPersonaJuridica);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_PersonaJuridicaPorID(int ID)
        {
            try {
                return entidadPersonaJuridicaNegocio.ObtenerEntidadPersonaJuridicaPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}