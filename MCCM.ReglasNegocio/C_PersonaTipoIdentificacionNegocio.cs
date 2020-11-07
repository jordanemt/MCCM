using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaTipoIdentificacionNegocio
    {
        C_PersonaTipoIdentificacionDatos c_PersonaTipoIdentificacionDatos = new C_PersonaTipoIdentificacionDatos();

        public string ListarPersonaTipoIdentificacion()
        {
            return c_PersonaTipoIdentificacionDatos.ListarPersonaTipoIdentificacion();
        }
        public void InsertarPersonaTipoIdentificacion(TMCCM_C_Persona_Tipo_Identificacion personaTipoIdentificacion)
        {
            c_PersonaTipoIdentificacionDatos.InsertarPersonaTipoIdentificacion(personaTipoIdentificacion);
        }
    }
}
