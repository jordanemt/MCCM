using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using Newtonsoft.Json;
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
        public String Insertar_E_Telefono(TMCCM_Entidad_Telefono telefono,int caso)
        {
            telefono.TN_ID_Caso = caso;
            entidadTelefonoNegocio.InsertarEntidadTelefono(telefono);
            return "S";
        }

        [HttpPost]
        public String Modificar_E_Telefono(TMCCM_Entidad_Telefono telefono)
        {
            entidadTelefonoNegocio.ActualizarEntidadTelefono(telefono);
            return "S";
        }

        [HttpGet]
        public String ListarEntidadTelefono(int caso)
        {
            return JsonConvert.SerializeObject(entidadTelefonoNegocio.ListarEntidadTelefonos(caso), 
                Formatting.Indented);
        }

        [HttpPost]
        public string EliminarTelefonoPorID(int telefonoID)
        {
            return entidadTelefonoNegocio.EliminarEntidadTelefono(telefonoID);
        }

        [HttpGet]
        public string ObtenerEntidadTelefonoPorID(int ID)
        {
            return JsonConvert.SerializeObject(entidadTelefonoNegocio.ObtenerEntidadTelefonoPorID(ID),
                Formatting.Indented);
        }

    }
}