using MCCM.Entidad.DTO;
using MCCM.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Controllers
{
    public class E_ArmaController : Controller
    {
        EntidadArmaNegocio entidadArmaNegocio = new EntidadArmaNegocio();
        // GET: E_Arma
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Insertar_E_Arma(TMCCM_EntidadArmaDTO entidadArmaDTO)
        {

            entidadArmaNegocio.InsertarEntidadArma(entidadArmaDTO);
            return "S";
        }
    }
}