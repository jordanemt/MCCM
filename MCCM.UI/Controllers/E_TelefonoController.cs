using MCCM.Entidad;
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
            try
            {
                telefono.TN_ID_Caso = caso;
                entidadTelefonoNegocio.InsertarEntidadTelefono(telefono);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String Insertar_Proveedor(TMCCM_C_Telefono_Empresa_Telefonica proveedor)
        {
            try
            {
                entidadTelefonoNegocio.InsertarProveedor(proveedor);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public String Modificar_E_Telefono(TMCCM_Entidad_Telefono telefono)
        {
            try
            {
                entidadTelefonoNegocio.ActualizarEntidadTelefono(telefono);
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public String ListarEntidadTelefono(int caso)
        {
            try
            {
                return entidadTelefonoNegocio.ListarEntidadTelefonos(caso);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public String ObtenerCatalogoProveedores()
        {
            try
            {
                return entidadTelefonoNegocio.ListarTelefonosProveedores();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public string EliminarTelefonoPorID(int telefonoID)
        {
            try
            {
                return entidadTelefonoNegocio.EliminarEntidadTelefono(telefonoID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string ObtenerEntidadTelefonoPorID(int ID)
        {
            try
            {
                return entidadTelefonoNegocio.ObtenerEntidadTelefonoPorID(ID);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}