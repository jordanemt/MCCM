using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class UsuarioDatos
    {
        public List<TMCCM_Usuario> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Usuario
                    .Where(e => e.TB_Eliminado == false)
                    .ToList();
            }
        }

        public TMCCM_Usuario ObtenerPorID(int id)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Usuario.Find(id);
            }
        }


        public TMCCM_Usuario Insertar(TMCCM_Usuario data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = false;
                TMCCM_Usuario newData = context.TMCCM_Usuario.Add(data);
                context.SaveChanges();
                return newData;
            }
        }

        public void Actualizar(TMCCM_Usuario data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void EliminarPorID(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Usuario data = context.TMCCM_Usuario.Find(id);
                data.TB_Eliminado = true;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
