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

        public IEnumerable<TMCCM_Grupo_Vehiculo> Listar()
        {
            return datos.Listar();
        }

        public TMCCM_Grupo_Vehiculo ObtenerPorId(int id)
        {
            return datos.ObtenerPorId(id);
        }

        public TMCCM_Grupo_Vehiculo Insertar(TMCCM_Grupo_Vehiculo data)
        {
            return datos.Insertar(data);
        }

        public TMCCM_Grupo_Vehiculo Actualizar(TMCCM_Grupo_Vehiculo data)
        {
            return datos.Actualizar(data);
        }

        public void EliminarPorId(int id)
        {
            datos.EliminarPorId(id);
        }
    }
}
