using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class GastoDatos
    {
        public IEnumerable<TMCCM_Gasto> GetAll() 
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Gasto.Where(e => e.TB_Eliminado == true).ToList();
            }
        }

        public TMCCM_Gasto GetById(int id)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Gasto.Find(id);
            }
        }


        public TMCCM_Gasto Insert(TMCCM_Gasto data) 
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                data.TF_Fecha = DateTime.Now;
                TMCCM_Gasto newData = context.TMCCM_Gasto.Add(data);
                context.SaveChanges();
                return newData;
            }
        }

        public void Update(TMCCM_Gasto data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                data.TF_Fecha = DateTime.Now;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Gasto data = context.TMCCM_Gasto.Find(id);
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
