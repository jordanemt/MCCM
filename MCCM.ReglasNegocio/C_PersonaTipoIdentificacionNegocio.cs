using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaTipoIdentificacionNegocio
    {
        C_PersonaTipoIdentificacionDatos c_PersonaTipoIdentificacionDatos = new C_PersonaTipoIdentificacionDatos();

        public List<TMCCM_C_PersonaTipoIdentificacionDTO> ListarPersonaTipoIdentificacion()
        {
            return c_PersonaTipoIdentificacionDatos.ListarPersonaTipoIdentificacion();
        }

    }
}
