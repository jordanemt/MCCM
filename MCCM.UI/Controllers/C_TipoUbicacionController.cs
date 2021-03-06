﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCCM.ReglasNegocio;
using MCCM.Entidad;

namespace MCCM.UI.Controllers
{
    public class C_TipoUbicacionController : Controller
    {
        C_TipoUbicacionNegocio c_TipoUbicacionNegocio = new C_TipoUbicacionNegocio();

        [HttpGet]
        public String ListarTipoUbicacion()
        {
            try { 
            return c_TipoUbicacionNegocio.ListaTipoUbicacion();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPost]
        public String InsertarTipoUbicacion(TMCCM_C_Ubicacion_Tipo_Ubicacion tipoUbicacion)
        {
            try { 
            c_TipoUbicacionNegocio.InsertarTipoUbicacion(tipoUbicacion);
            return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}