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
        public List<TMCCM_C_UbicacionCantonDTO> ListarUbicacionCanton(int idProvincia)
        {
            return c_UbicacionCantonDatos.ListarUbicacionCanton(idProvincia);
        }

        public TMCCM_C_Ubicacion_Canton ObtenerUbicacionCantonPorID(int ID)
        {
           
            return c_UbicacionCantonDatos.ObtenerUbicacionCantonPorID(ID);
        }

    }
}
