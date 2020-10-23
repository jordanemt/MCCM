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
    public class C_VehiculoColorNegocio
    {
        C_VehiculoColorDatos c_VehiculoColorDatos = new C_VehiculoColorDatos();
        public List<TMCCM_C_VehiculoColorDTO> ListarVehiculoColor()
        {
            return c_VehiculoColorDatos.ListarVehiculoColor();
        }

        public TMCCM_C_Vehiculo_Color ObtenerVehiculoColorPorID(int ID)
        {
            return c_VehiculoColorDatos.ObtenerVehiculoColorPorID(ID);
        }
    }
}
