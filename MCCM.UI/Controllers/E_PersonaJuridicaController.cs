using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System.IO;

namespace MCCM.UI.Controllers
{
    public class E_PersonaJuridicaController : Controller
    {
        EntidadPersonaJuridicaNegocio entidadPersonaJuridicaNegocio = new EntidadPersonaJuridicaNegocio();
     
        [HttpPost]
        public String Insertar_E_PersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            HttpPostedFileBase file = entidadPersonaJuridicaDTO.TB_Fotografia;
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            entidadPersonaJuridicaDTO.imgTemporal = fileData;

            entidadPersonaJuridicaNegocio.InsertarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
            return "S";
        }
        [HttpGet]
        public String Listar_E_PersonaJuridica(int caso)
        {
            List<TMCCM_EntidadPersonaJuridicaDTO> entidadPersonaJuridicaDTO= entidadPersonaJuridicaNegocio.ListarEntidadPersonaJuridicas(caso);
            return JsonConvert.SerializeObject(entidadPersonaJuridicaDTO, Formatting.Indented);
        }
        [HttpPost]
        public String Eliminar_E_PersonaJuridicaPorID(int entidadPersonaJuridicaID)
        {
            return entidadPersonaJuridicaNegocio.EliminarEntidadPersonaJuridica(entidadPersonaJuridicaID);
        }
        [HttpPost]
        public String Modificar_E_PersonaJuridica(TMCCM_EntidadPersonaJuridicaDTO entidadPersonaJuridicaDTO)
        {
            HttpPostedFileBase file = entidadPersonaJuridicaDTO.TB_Fotografia;
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            entidadPersonaJuridicaDTO.imgTemporal = fileData;
            entidadPersonaJuridicaNegocio.ActualizarEntidadPersonaJuridica(entidadPersonaJuridicaDTO);
            return "S";
        }
        [HttpGet]
        public String Obtener_E_PersonaJuridicaPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadPersonaJuridicaNegocio.ObtenerEntidadPersonaJuridicaPorID(ID), Formatting.Indented);
        }
    }
}