using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class E_TelefonoController : Controller
    {

        EntidadTelefonoNegocio entidadTelefonoNegocio = new EntidadTelefonoNegocio();


        [HttpPost]
        public String Insertar_E_Telefono(TMCCM_EntidadTelefonoDTO telefono,int caso)
        {
            telefono.TN_ID_Caso = caso;
            entidadTelefonoNegocio.InsertarEntidadTelefono(telefono);
            return "S";
        }
    }
}