using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class Grupo_UsuarioDatos
    {
        public IEnumerable<TMCCM_Grupo_Usuario> GetAll()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo_Usuario.Where(e => e.TB_Eliminado == true).ToList();
            }
        }

        public TMCCM_Grupo_Usuario GetById(int id)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo_Usuario.Find(id);
            }
        }


        public TMCCM_Grupo_Usuario Insert(TMCCM_Grupo_Usuario data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                TMCCM_Grupo_Usuario newData = context.TMCCM_Grupo_Usuario.Add(data);
                context.SaveChanges();
                return newData;
            }
        }

        public void Update(TMCCM_Grupo_Usuario data)
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
                TMCCM_Grupo_Usuario data = context.TMCCM_Grupo_Usuario.Find(id);
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
