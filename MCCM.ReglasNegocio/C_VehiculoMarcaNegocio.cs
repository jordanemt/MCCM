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
    public class C_VehiculoMarcaNegocio
    {
        C_VehiculoMarcaDatos c_VehiculoMarcaDatos = new C_VehiculoMarcaDatos();
        public List<TMCCM_C_VehiculoMarcaDTO> ListarVehiculoMarca()
        {
            return c_VehiculoMarcaDatos.ListarVehiculoMarca(); ;
        }
    }
}
