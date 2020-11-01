using System;
using System.Data.Entity.Core;
using System.Net;
using System.Web;

namespace MCCM.AccesoDatos.Exceptions
{
    class ErrorHandler : ArgumentException
    {
        private ErrorHandler(String message, Exception e) : base(message, e) { }

        public static ArgumentException Handle(Exception e) 
        {
            Type type = e.GetType();

            if (typeof(ConflictoConPlacaException).IsAssignableFrom(type)) return new ErrorHandler(e.Message, e);
            if (typeof(EntityException).IsAssignableFrom(type)) return new ErrorHandler(e.Message, e);

            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return new ErrorHandler("Error inesperado", e);
        }
    }
}
