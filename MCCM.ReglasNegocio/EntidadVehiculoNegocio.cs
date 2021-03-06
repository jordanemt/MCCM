﻿using MCCM.AccesoDatos;
using MCCM.Entidad;

namespace MCCM.ReglasNegocio
{
    public class EntidadVehiculoNegocio
    {
        EntidadVehiculoDatos entidadVehiculoDatos = new EntidadVehiculoDatos();
        public void InsertarEntidadVehiculo(TMCCM_Entidad_Vehiculo  entidadVehiculo)
        {
            entidadVehiculoDatos.InsertarEntidadVehiculo(entidadVehiculo);
        }
        public void ActualizarEntidadVehiculo(TMCCM_Entidad_Vehiculo entidadVehiculo)
        {
            entidadVehiculoDatos.ActualizarEntidadVehiculo(entidadVehiculo);
        }

        public string EliminarEntidadVehiculo(int ID)
        {
            entidadVehiculoDatos.EliminarEntidadVehiculo(ID);
            return "S";
        }
        public string ListarEntidadVehiculo(int caso)
        {
            return entidadVehiculoDatos.ListarEntidadVehiculos(caso);
        }

        public string ObtenerEntidadVehiculoPorID(int ID)
        {
            return entidadVehiculoDatos.ObtenerEntidadVehiculoPorID(ID);
        }
    }
}
