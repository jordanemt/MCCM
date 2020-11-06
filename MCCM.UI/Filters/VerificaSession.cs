using MCCM.Entidad;
using MCCM.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCCM.UI.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private TMCCM_Usuario oUsuario;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);
                oUsuario = (TMCCM_Usuario)HttpContext.Current.Session["User"];
                if (oUsuario==null)
                {
                    if (filterContext.Controller is DashboardController == false) 
                    {
                        filterContext.HttpContext.Response.Redirect("~/Dashboard/Login");

                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Dashboard/Login");
            }
            
        }
    }
}