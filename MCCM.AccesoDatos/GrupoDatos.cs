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
                return context.TMCCM_Grupo
                    .Where(e => e.TB_Eliminado == true)
                    .ToList();
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
                var data = context.TMCCM_Grupo.Find(id);
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
                context.SaveChanges();
                return newData;
            }
        }

        public TMCCM_Grupo Actualizar(TMCCM_Grupo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                context.Entry(data).State = EntityState.Modified;
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
