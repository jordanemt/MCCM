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
    public class C_VehiculoClaseNegocio
    {
        C_VehiculoClaseDatos c_VehiculoClaseDatos = new C_VehiculoClaseDatos();
        public string ListarVehiculoClase()
        {
            return c_VehiculoClaseDatos.ListarVehiculoClase();
        }
        public void InsertarVehiculoClase(TMCCM_C_Vehiculo_Clase vehiculoClase)
        {
            c_VehiculoClaseDatos.InsertarVehiculoClase(vehiculoClase);
        }
    }
}
