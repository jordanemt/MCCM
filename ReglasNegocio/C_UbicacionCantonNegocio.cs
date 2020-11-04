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
    public class C_UbicacionCantonNegocio
    {
        C_UbicacionCantonDatos c_UbicacionCantonDatos = new C_UbicacionCantonDatos();
        public string ListarUbicacionCanton(int idProvincia)
        {
            return c_UbicacionCantonDatos.ListarUbicacionCanton(idProvincia);
        }
        public void InsertarUbicacionCanton(TMCCM_C_Ubicacion_Canton ubicacionCanton)
        {
            c_UbicacionCantonDatos.InsertarUbicacionCanton(ubicacionCanton);
        }

    }
}
