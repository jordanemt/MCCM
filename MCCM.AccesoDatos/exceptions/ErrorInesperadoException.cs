using System;
using System.Net;
using System.Web;
using System.Web.UI;

namespace MCCM.AccesoDatos.exceptions
{
    class ErrorInesperadoException : Exception
    {
        public ErrorInesperadoException() : base("Error inesperado") 
        {
            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        }
    }
}
