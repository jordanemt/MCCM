using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public String Insertar_E_Persona(TMCCM_Entidad_Persona entidadPersona, HttpPostedFileBase imagenPersona)
        {
            try { 
            if (imagenPersona != null)
            {
                HttpPostedFileBase file = imagenPersona;
                var length = file.InputStream.Length; //Length: 103050706
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
                entidadPersona.TB_Fotografia = fileData;
            }

            entidadPersonaNegocio.InsertarEntidadPersona(entidadPersona);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Listar_E_Persona(int caso)
        {
            try { 
            return entidadPersonaNegocio.ListarEntidadPersonas(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Eliminar_E_PersonaPorID(int entidadPersonaID)
        {
            try { 
            return entidadPersonaNegocio.EliminarEntidadPersona(entidadPersonaID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String Modificar_E_Persona(TMCCM_Entidad_Persona entidadPersona, HttpPostedFileBase imagenPersona)
        {
            try { 
            if (imagenPersona != null)
            {
                HttpPostedFileBase file = imagenPersona;
                var length = file.InputStream.Length; //Length: 103050706
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
                entidadPersona.TB_Fotografia = fileData;
            }
            entidadPersonaNegocio.ActualizarEntidadPersona(entidadPersona);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public String Obtener_E_PersonaPorID(int ID)
        {
            try { 
            return entidadPersonaNegocio.ObtenerEntidadPersonaPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}






