using MCCM.Entidad;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class Grupo_VehiculoDatos
    {
        public IEnumerable<TMCCM_Grupo_Vehiculo> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo_Vehiculo
                    .Where(e => e.TB_Eliminado == false)
                    .Include(e => e.TMCCM_Vehiculo)
                    .ToList();
            }
        }

        public IEnumerable<TMCCM_Grupo_Vehiculo> ListarPorGrupoId(int idGrupo)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo_Vehiculo
                    .Where(e => e.TB_Eliminado == false && e.TN_ID_Grupo == idGrupo)
                    .Include(e => e.TMCCM_Vehiculo)
                    .ToList();
            }
        }

        public TMCCM_Grupo_Vehiculo ObtenerPorId(int idGrupo, int idVehiculo)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Grupo_Vehiculo
                    .Where(e => e.TN_ID_Grupo == idGrupo && e.TN_ID_Vehiculo == idVehiculo)
                    .Include(e => e.TMCCM_Vehiculo)
                    .FirstOrDefault();
            }
        }


        public TMCCM_Grupo_Vehiculo Insertar(TMCCM_Grupo_Vehiculo data)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Vehiculo vehiculo = context.TMCCM_Vehiculo.Find(data.TN_ID_Vehiculo);
                vehiculo.TB_En_Uso = true;
                context.Entry(vehiculo).State = EntityState.Modified;
                data.TB_Eliminado = false;
                data.TN_Km_Inicio = vehiculo.TC_Kilometraje;
                TMCCM_Grupo_Vehiculo newData = context.TMCCM_Grupo_Vehiculo.Add(data);
                context.Entry(newData).Reference(e => e.TMCCM_Vehiculo).Load();
                context.SaveChanges();
                return newData;
            }
        }

        public TMCCM_Grupo_Vehiculo Actualizar(TMCCM_Grupo_Vehiculo data)
        {
            using (var context = new MCCMEntities())
            {
                if (data.TN_Km_Regreso != null) 
                {
                    TMCCM_Vehiculo vehiculo = context.TMCCM_Vehiculo.Find(data.TN_ID_Vehiculo);
                    vehiculo.TB_En_Uso = false;
                    vehiculo.TC_Kilometraje = data.TN_Km_Regreso;
                    context.Entry(vehiculo).State = EntityState.Modified;
                }
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.Entry(data).Reference(e => e.TMCCM_Vehiculo).Load();
                context.SaveChanges();
                return data;
            }
        }

        public void EliminarPorId(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Grupo_Vehiculo data = context.TMCCM_Grupo_Vehiculo.Find(id);
                data.TB_Eliminado = true;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TMCCM_Grupo_Vehiculo Devolver(TMCCM_Grupo_Vehiculo data)
        {
            using (var context = new MCCMEntities())
            {
                
                context.SaveChanges();
                return data;
            }
        }
    }
}
