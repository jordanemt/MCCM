using MCCM.AccesoDatos;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class Grupo_VehiculoNegocio
    {
        private Grupo_VehiculoDatos datos;

        public Grupo_VehiculoNegocio()
        {
            datos = new Grupo_VehiculoDatos();
        }

        public IEnumerable<TMCCM_Grupo_Vehiculo> GetAll()
        {
            return datos.GetAll();
        }

        public TMCCM_Grupo_Vehiculo GetById(int id)
        {
            return datos.GetById(id);
        }

        public TMCCM_Grupo_Vehiculo Insert(TMCCM_Grupo_Vehiculo data)
        {
            return datos.Insert(data);
        }

        public void Update(TMCCM_Grupo_Vehiculo data)
        {
            datos.Update(data);
        }

        public void DeleteById(int id)
        {
            datos.DeleteById(id);
        }
    }
}
