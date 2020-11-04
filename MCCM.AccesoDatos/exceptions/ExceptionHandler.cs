using System;
using System.Data.Entity.Core;
using System.Net;
using System.Web;

namespace MCCM.AccesoDatos.exceptions
{
    public class ExceptionHandler
    {
        public static Exception Handle(Exception e)
        {
            Type typeException = e.GetType();

            if (typeof(EntityException).IsAssignableFrom(typeException)) {
                HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.BadGateway;
                return new ArgumentException("Error con la base de datos", e); 
            }

            return new ErrorInesperadoException();
        }
    }
}
