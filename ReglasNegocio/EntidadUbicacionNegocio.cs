using MCCM.AccesoDatos;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadUbicacionNegocio
    {
        
        EntidadUbicacionDatos entidadUbicacionDatos = new  EntidadUbicacionDatos();
        public void InsertarEntidadUbicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            entidadUbicacionDatos.InsertarEntidadUbicacion(entidadUbicacion);
        }
        public void ActualizarEntidadUbicacion(TMCCM_Entidad_Ubicacion entidadUbicacion)
        {
            entidadUbicacionDatos.ActualizarEntidadUbicacion(entidadUbicacion);
        }

        public string EliminarEntidadUbicacion(int ID)
        {
            entidadUbicacionDatos.EliminarEntidadUbicacion(ID);
            return "S";
        }
        public string ListarEntidadUbicaciones(int caso)
        {
            return entidadUbicacionDatos.ListarEntidadUbicacion(caso);
        }

        public string ObtenerEntidadUbicacionPorID(int ID)
        {
            return entidadUbicacionDatos.ObtenerEntidadUbicacionPorID(ID);
        }
    }
}
