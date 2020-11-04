﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_PersonaTipoIdentificacionController : Controller
    {
        C_PersonaTipoIdentificacionNegocio c_PersonaTipoIdentificacionNegocio = new C_PersonaTipoIdentificacionNegocio();

        public JsonResult ListarPersonaTipoIdentificacion()
        {

            return Json(c_PersonaTipoIdentificacionNegocio.ListarPersonaTipoIdentificacion(), JsonRequestBehavior.AllowGet);
        }
        public String InsertarPersonaTipoIdentificacion(TMCCM_C_Persona_Tipo_Identificacion persona_Tipo_Identificacion)
        {
            c_PersonaTipoIdentificacionNegocio.InsertarPersonaTipoIdentificacion(persona_Tipo_Identificacion);
            return "S";
        }
    }
}