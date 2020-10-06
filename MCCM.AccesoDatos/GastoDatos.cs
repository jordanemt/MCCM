using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class GastoDatos
    {
        public IEnumerable<TMCCM_Gasto> GetAll() 
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Gasto.ToList();
            }
        }

        public TMCCM_Gasto Insert(TMCCM_Gasto gasto) 
        {
            using (var context = new MCCMEntities())
            {
                gasto.TB_Eliminado = true;
                gasto.TF_Fecha = DateTime.Now;
                TMCCM_Gasto newGasto = context.TMCCM_Gasto.Add(gasto);
                context.SaveChanges();
                return newGasto;
            }
        }

        public void Update(TMCCM_Gasto gasto)
        {
            using (var context = new MCCMEntities())
            {
                gasto.TF_Fecha = DateTime.Now;
                context.Entry(gasto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Gasto gasto = context.TMCCM_Gasto.Find(id);
                gasto.TB_Eliminado = false;
                gasto.TF_Fecha = DateTime.Now;
                context.Entry(gasto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
