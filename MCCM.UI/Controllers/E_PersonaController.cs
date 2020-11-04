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
        public String Insertar_E_Persona(TMCCM_Entidad_Persona persona, HttpPostedFileBase imagen)
        {
            HttpPostedFileBase file = imagen;
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            persona.TB_Fotografia = fileData;


            entidadPersonaNegocio.Insertar(persona);
            return "S";
        }
        [HttpGet]
        public String Listar_E_Persona(int caso)
        {
            List<TMCCM_EntidadPersonaDTO> entidadPersonaDTO = entidadPersonaNegocio.ListarEntidadPersonas(caso);

            foreach (TMCCM_EntidadPersonaDTO itemPersona in entidadPersonaDTO)
            {
                string imreBase64Data = Convert.ToBase64String(itemPersona.imgTemporal);
                string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                itemPersona.imgString = imgDataURL;


            }
            return JsonConvert.SerializeObject(entidadPersonaDTO, Formatting.Indented);
        }
        [HttpPost]
        public String Eliminar_E_PersonaPorID(int entidadPersonaID)
        {
            return entidadPersonaNegocio.EliminarEntidadPersona(entidadPersonaID);
        }
        [HttpPost]
        public String Modificar_E_Persona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            HttpPostedFileBase file = entidadPersonaDTO.TB_Fotografia;
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            entidadPersonaDTO.imgTemporal = fileData;

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






