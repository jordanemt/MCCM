using System;
using System.Net;
using System.Web;

namespace MCCM.AccesoDatos.exceptions
{
    class PlacaVehiculoException : Exception
    {
        public PlacaVehiculoException() : base("La placa ya existe")
        {
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Conflict;
        }
    }
}
