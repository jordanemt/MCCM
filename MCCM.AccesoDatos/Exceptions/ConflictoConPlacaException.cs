using System;
using System.Net;
using System.Web;

namespace MCCM.AccesoDatos.Exceptions
{
    public class ConflictoConPlacaException : Exception
    {
        public ConflictoConPlacaException() : base("La placa ya existe") {
            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.Conflict;
        }
    }
}
