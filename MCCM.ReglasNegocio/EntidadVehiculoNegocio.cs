using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadVehiculoNegocio
    {
        EntidadVehiculoDatos entidadVehiculoDatos = new EntidadVehiculoDatos();
        public void InsertarEntidadVehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            entidadVehiculoDatos.InsertarEntidadVehiculo(entidadVehiculoDTO);
        }
        public void ActualizarEntidadVehiculo(TMCCM_EntidadVehiculoDTO entidadVehiculoDTO)
        {
            entidadVehiculoDatos.ActualizarEntidadVehiculo(entidadVehiculoDTO);
        }

        public string EliminarEntidadVehiculo(int ID)
        {
            entidadVehiculoDatos.EliminarEntidadVehiculo(ID);
            return "S";
        }
        public List<TMCCM_EntidadVehiculoDTO> ListarEntidadPersonas()
        {
            return entidadVehiculoDatos.ListarEntidadVehiculos();
        }

        public TMCCM_EntidadVehiculoDTO ObtenerEntidadVehiculoPorID(int ID)
        {
            return entidadVehiculoDatos.ObtenerEntidadVehiculoPorID(ID);
        }
    }
}
