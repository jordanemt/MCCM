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

        public IEnumerable<TMCCM_Grupo> GetAll()
        {
            return datos.GetAll();
        }

        public TMCCM_Grupo GetById(int id)
        {
            return datos.GetById(id);
        }


        public TMCCM_Grupo Insert(TMCCM_Grupo data)
        {
            return datos.Insert(data);
        }

        public void Update(TMCCM_Grupo data)
        {
            datos.Update(data);
        }

        public void DeleteById(int id)
        {
            datos.DeleteById(id);
        }
    }
}
