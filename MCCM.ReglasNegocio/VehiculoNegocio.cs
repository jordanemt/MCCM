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

        public IEnumerable<TMCCM_Vehiculo> GetAll()
        {
            return datos.GetAll();
        }

        public TMCCM_Vehiculo GetById(int id)
        {
            return datos.GetById(id);
        }

        public TMCCM_Vehiculo Insert(TMCCM_Vehiculo data)
        {
            return datos.Insert(data);
        }

        public void Update(TMCCM_Vehiculo data)
        {
            datos.Update(data);
        }

        public void DeleteById(int id)
        {
            datos.DeleteById(id);
        }
    }
}
