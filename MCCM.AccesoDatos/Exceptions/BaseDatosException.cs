using System.Data.Entity.Core;
using System.Net;
using System.Web;

namespace MCCM.AccesoDatos.Exceptions
{
    class BaseDatosException : EntityException
    {
        BaseDatosException() : base("Error con la base de datos") {
            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.BadGateway;
        }
    }
}
