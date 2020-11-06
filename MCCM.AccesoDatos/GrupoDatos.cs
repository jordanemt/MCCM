using MCCM.AccesoDatos.exceptions;
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
        public IEnumerable<TMCCM_Grupo> ListarPorCaso(int idCaso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    List<TMCCM_Grupo> data = context.TMCCM_Grupo
                        .Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso)
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
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_Grupo ObtenerPorId(int id)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    TMCCM_Grupo data = context.TMCCM_Grupo.Find(id);
                    foreach (TMCCM_Grupo_Usuario item in data.TMCCM_Grupo_Usuario)
                    {
                        context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                    }
                    List<TMCCM_Grupo_Usuario> toRemoveList = data.TMCCM_Grupo_Usuario.Where(e => e.TMCCM_Usuario.TB_Eliminado == true).ToList();
                    foreach (var toRemove in toRemoveList)
                    {
                        data.TMCCM_Grupo_Usuario.Remove(toRemove);
                    }
                    return data;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }


        public TMCCM_Grupo Insertar(TMCCM_Grupo data)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    data.TB_Eliminado = false;
                    TMCCM_Grupo newData = context.TMCCM_Grupo.Add(data);
                    foreach (TMCCM_Grupo_Usuario item in newData.TMCCM_Grupo_Usuario)
                    {
                        context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                    }
                    context.SaveChanges();
                    return newData;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_Grupo Actualizar(TMCCM_Grupo data)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    data.TB_Eliminado = false;
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
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public void EliminarPorId(int id)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    TMCCM_Grupo data = context.TMCCM_Grupo.Find(id);
                    data.TB_Eliminado = true;
                    foreach (TMCCM_Grupo_Usuario item in data.TMCCM_Grupo_Usuario)
                    {
                        item.TB_Eliminado = true;
                    }
                    context.Entry(data).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_Grupo ObtenerGrupoDeMandoActivoPorIdCaso(int idCaso) {
            try
            {
                using (var context = new MCCMEntities())
                {
                    DateTime now = DateTime.Now;
                    //Obtener los grupos de mando activos en el dia (ordenados por horario)
                    List<TMCCM_Grupo> dataList = context.TMCCM_Grupo
                        .Where(e =>
                            e.TB_Eliminado == false &&
                            e.TN_ID_Caso == idCaso &&
                            e.TB_Mando == true &&
                            DateTime.Compare((DateTime)e.TF_Fecha_Inicio, now) <= 0 &&
                            (e.TF_Fecha_Final == null || DateTime.Compare((DateTime)e.TF_Fecha_Final, now) >= 0)
                            ).OrderBy(e => e.TF_Hora).ToList();

                    //Obtener el grupo en el horario vigente
                    TMCCM_Grupo data = null;
                    int indexMasUno = 1;
                    foreach (TMCCM_Grupo item in dataList)
                    {
                        if (item == dataList.LastOrDefault())
                        {
                            data = item;
                            break;
                        }
                        else if (TimeSpan.Compare((TimeSpan)item.TF_Hora, now.TimeOfDay) <= 0 && 
                            TimeSpan.Compare((TimeSpan)dataList[indexMasUno].TF_Hora, now.TimeOfDay) > 0) 
                        {
                            data = item;
                            break;
                        }
                        indexMasUno += 1;
                    }

                    //Cargar usuarios
                    if (data != null) 
                    {
                        foreach (TMCCM_Grupo_Usuario item in data.TMCCM_Grupo_Usuario)
                        {
                            context.Entry(item).Reference(e => e.TMCCM_Usuario).Load();
                        }
                        //Borrar
                        List<TMCCM_Grupo_Usuario> toRemoveList = data.TMCCM_Grupo_Usuario.Where(e => e.TMCCM_Usuario.TB_Eliminado == true).ToList();
                        foreach (var toRemove in toRemoveList)
                        {
                            data.TMCCM_Grupo_Usuario.Remove(toRemove);
                        }
                    }
                    return data;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }
    }
}
