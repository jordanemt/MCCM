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

        public IEnumerable<TMCCM_Gasto> GetAll()
        {
            return datos.GetAll();
        }

        public TMCCM_Gasto GetById(int id)
        {
            return datos.GetById(id);
        }


        public TMCCM_Gasto Insert(TMCCM_Gasto data)
        {
            return datos.Insert(data);
        }

        public void Update(TMCCM_Gasto data)
        {
            datos.Update(data);
        }

        public void DeleteById(int id)
        {
            datos.DeleteById(id);
        }
    }
}
