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
    public class C_TipoUbicacionNegocio
    {
        C_TipoUbicacionDatos c_TipoUbicacionDatos = new C_TipoUbicacionDatos();

        public List<TMCCM_C_TipoUbicacionDTO> ListaTipoUbicacion()
        {
            return c_TipoUbicacionDatos.ListarTipoUbicacion();
        }

    }
}
