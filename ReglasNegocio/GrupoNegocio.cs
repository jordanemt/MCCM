using MCCM.AccesoDatos;
using MCCM.Entidad;
using System.Collections.Generic;

namespace MCCM.ReglasNegocio
{
    public class GrupoNegocio
    {
        private GrupoDatos datos;

        public GrupoNegocio()
        {
            datos = new GrupoDatos();
        }

        public IEnumerable<TMCCM_Grupo> ListarPorCaso(int idCaso)
        {
            return datos.ListarPorCaso(idCaso);
        }

        public TMCCM_Grupo ObtenerPorId(int id)
        {
            return datos.ObtenerPorId(id);
        }


        public TMCCM_Grupo Insertar(TMCCM_Grupo data)
        {
            return datos.Insertar(data);
        }

        public TMCCM_Grupo Actualizar(TMCCM_Grupo data)
        {
            return datos.Actualizar(data);
        }

        public void EliminarPorId(int id)
        {
            datos.EliminarPorId(id);
        }
    }
}
