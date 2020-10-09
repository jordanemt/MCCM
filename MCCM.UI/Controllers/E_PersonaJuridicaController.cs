using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad.DTO;

namespace MCCM.UI.Controllers
{
    public class E_PersonaJuridicaController : Controller
    {
        EntidadPersonaJuridicaNegocio entidadPersonaJuridicaNegocio = new EntidadPersonaJuridicaNegocio();
        // GET: E_Persona
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String Insertar_E_PersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            //return Path.GetFileNameWithoutExtension(entidadPersonaDTO.TB_Fotografia.FileName); 

            entidadPersonaJuridicaNegocio.InsertarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
            return "S";
        }
    }
}