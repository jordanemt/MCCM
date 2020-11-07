using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_UbicacionProvinciaNegocio
    {
        C_UbicacionProvinciaDatos c_UbicacionProvinciaDatos = new C_UbicacionProvinciaDatos();
        public string ListarUbicacionProvincia()
        {
           
            return c_UbicacionProvinciaDatos.ListarUbicacionProvincia();
        }
        public void InsertarUbicacionProvincia(TMCCM_C_Ubicacion_Provincia ubicacionProvincia)
        {
            c_UbicacionProvinciaDatos.InsertarUbicacionProvincia(ubicacionProvincia);
        }
    }

}

