using MCCM.AccesoDatos;
using MCCM.Entidad;
using System.Collections.Generic;

namespace MCCM.ReglasNegocio
{
    public class VehiculoNegocio
    {
        private VehiculoDatos datos;

        public VehiculoNegocio()
        {
            datos = new VehiculoDatos();
        }

        public IEnumerable<TMCCM_Vehiculo> Listar()
        {
            return datos.Listar();
        }

        public TMCCM_Vehiculo Insertar(TMCCM_Vehiculo data)
        {
            return datos.Insertar(data);
        }
    }
}
