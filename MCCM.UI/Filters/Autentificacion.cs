using MCCM.Entidad;
using MCCM.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autentificacion : AuthorizeAttribute
    {
        private TMCCM_Usuario oUsuario;
        private MCCMEntities context = new MCCMEntities();
        private int idRol;

        public Autentificacion(int idRol = 0)
        {
            this.idRol = idRol;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                oUsuario = (TMCCM_Usuario)HttpContext.Current.Session["User"];
                var operacion = context.TMCCM_Usuario
                    .Where(e => e.TN_ID_Usuario == oUsuario.TN_ID_Usuario)
                    .Include(e => e.TMCCM_Rol).FirstOrDefault();
                if (operacion == null)
                {

                    

                }
            }
            catch
            {
                filterContext.HttpContext.Response.Redirect("~/Dashboard/Login");
            }


        }
    }
}