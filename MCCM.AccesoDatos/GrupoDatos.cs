using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class GrupoDatos
    {
        public IEnumerable<TMCCM_Grupo> GetAll()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo.Where(e => e.TB_Eliminado == true).ToList();
            }
        }

        public TMCCM_Grupo GetById(int id)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo.Find(id);
            }
        }


        public TMCCM_Grupo Insert(TMCCM_Grupo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                TMCCM_Grupo newData = context.TMCCM_Grupo.Add(data);
                context.SaveChanges();
                return newData;
            }
        }

        public void Update(TMCCM_Grupo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Grupo data = context.TMCCM_Grupo.Find(id);
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
