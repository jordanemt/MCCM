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
        public IEnumerable<TMCCM_Grupo> Listar()
        {
            using (var context = new MCCMEntities())
            {
                List<TMCCM_Grupo> data = context.TMCCM_Grupo
                    .Where(e => e.TB_Eliminado == true)
                    .Include(e => e.TMCCM_Grupo_Usuario)
                    .ToList();

                foreach (TMCCM_Grupo grupo in data) 
                {
                    foreach (TMCCM_Grupo_Usuario item in grupo.TMCCM_Grupo_Usuario)
                    {
                        context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                    }
                    List<TMCCM_Grupo_Usuario> toRemoveList = grupo.TMCCM_Grupo_Usuario.Where(e => e.TMCCM_Usuario.TB_Eliminado == true).ToList();
                    foreach (var toRemove in toRemoveList)
                    {
                        grupo.TMCCM_Grupo_Usuario.Remove(toRemove);
                    }
                }

                return data;
            }
        }

        public IEnumerable<TMCCM_Grupo> ListarPorCaso(int idCaso)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo
                    .Where(e => e.TB_Eliminado == true && e.TN_ID_Caso == idCaso)
                    .ToList();
            }
        }

        public TMCCM_Grupo ObtenerPorId(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Grupo data = context.TMCCM_Grupo.Find(id);
                foreach (TMCCM_Grupo_Usuario item in data.TMCCM_Grupo_Usuario) 
                {
                    context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                }
                return data;
            }
        }


        public TMCCM_Grupo Insertar(TMCCM_Grupo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                data.TF_Fecha_Inicio = DateTime.Now;
                TMCCM_Grupo newData = context.TMCCM_Grupo.Add(data);
                foreach (TMCCM_Grupo_Usuario item in newData.TMCCM_Grupo_Usuario)
                {
                    context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                }
                context.SaveChanges();
                return newData;
            }
        }

        public TMCCM_Grupo Actualizar(TMCCM_Grupo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                context.TMCCM_Grupo_Usuario.RemoveRange(context.TMCCM_Grupo_Usuario.Where(e => e.TN_ID_Grupo == data.TN_ID_Grupo));
                context.TMCCM_Grupo_Usuario.AddRange(data.TMCCM_Grupo_Usuario);
                context.Entry(data).State = EntityState.Modified;
                foreach (TMCCM_Grupo_Usuario item in data.TMCCM_Grupo_Usuario)
                {
                    context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                }
                context.SaveChanges();
                return context.Entry(data).Entity;
            }
        }

        public void EliminarPorId(int id)
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
