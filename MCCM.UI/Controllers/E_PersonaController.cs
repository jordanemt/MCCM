﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System.IO;
using MCCM.ReglasNegocio;

namespace MCCM.UI.Controllers
{
    public class E_PersonaController : Controller
    {

        EntidadPersonaNegocio entidadPersonaNegocio = new EntidadPersonaNegocio();
        // GET: E_Persona
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String Insertar_E_Persona(TMCCM_EntidadPersonaDTO entidadPersonaDTO)
        {
            //return Path.GetFileNameWithoutExtension(entidadPersonaDTO.TB_Fotografia.FileName); 

            entidadPersonaNegocio.InsertarEntidadPersona(entidadPersonaDTO);
            return "S";
        }

    }
}