using MCCM.AccesoDatos;
using MCCM.Entidad;
using System.Collections.Generic;

namespace MCCM.ReglasNegocio
{
    public class GastoNegocio
    {
        private GastoDatos datos;

        public GastoNegocio()
        {
            datos = new GastoDatos();
        }

        public IEnumerable<TMCCM_Gasto> Listar()
        {
            return datos.Listar();
        }

        public IEnumerable<TMCCM_Gasto> ListarPorCaso(int idCaso)
        {
            return datos.ListarPorCaso(idCaso);
        }

        public TMCCM_Gasto ObtenerPorId(int id)
        {
            return datos.ObtenerPorId(id);
        }


        public TMCCM_Gasto Insertar(TMCCM_Gasto data)
        {
            return datos.Insertar(data);
        }

        public TMCCM_Gasto Actualizar(TMCCM_Gasto data)
        {
            return datos.Actualizar(data);
        }

        public void EliminarPorId(int id)
        {
            datos.EliminarPorId(id);
        }

        public IEnumerable<TMCCM_C_Gasto_Tipo_Gasto> ListarTipoGasto()
        {
            return datos.ListarTipoGasto();
        }
    }
}
