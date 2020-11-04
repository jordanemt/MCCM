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

        public TMCCM_Vehiculo ObtenerPorId(int id)
        {
            return datos.ObtenerPorId(id);
        }

        public TMCCM_Vehiculo Insertar(TMCCM_Vehiculo data)
        {
            return datos.Insertar(data);
        }

        public TMCCM_Vehiculo Actualizar(TMCCM_Vehiculo data)
        {
            return datos.Actualizar(data);
        }

        public void DeleteById(int id)
        {
            datos.EliminarPorId(id);
        }
    }
}
