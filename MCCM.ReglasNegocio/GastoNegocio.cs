using MCCM.AccesoDatos;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public TMCCM_Gasto Insert(TMCCM_Gasto gasto)
        {
            return datos.Insert(gasto);
        }

        public void Update(TMCCM_Gasto gasto)
        {
            datos.Update(gasto);
        }

        public void DeleteById(int id)
        {
            datos.DeleteById(id);
        }
    }
}
