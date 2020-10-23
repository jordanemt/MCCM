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
    class C_UbicacionProvinciaNegocio
    {
        C_UbicacionProvinciaDatos c_UbicacionProvinciaDatos = new C_UbicacionProvinciaDatos();
        public List<TMCCM_C_UbicacionProvinciaDTO> ListarUbicacionProvincia()
        {
           
            return c_UbicacionProvinciaDatos.ListarUbicacionProvincia();
        }

        public TMCCM_C_Ubicacion_Provincia ObtenerUbicacionProvinciaPorID(int ID)
        {
            return c_UbicacionProvinciaDatos.ObtenerUbicacionProvinciaPorID(ID);
        }
    }


}

