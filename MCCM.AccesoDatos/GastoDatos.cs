using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class GastoDatos
    {
        public IEnumerable<TMCCM_Gasto> ListarPorCaso(int idCaso)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    return context.TMCCM_Gasto
                        .Where(e => e.TB_Eliminado == false && e.TN_ID_Caso == idCaso)
                        .Include(e => e.TMCCM_C_Gasto_Tipo_Gasto)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_Gasto ObtenerPorId(int id)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    var data = context.TMCCM_Gasto.Find(id);
                    context.Entry(data).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
                    return data;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }


        public TMCCM_Gasto Insertar(TMCCM_Gasto data)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    data.TB_Eliminado = false;
                    TMCCM_Gasto newData = context.TMCCM_Gasto.Add(data);
                    context.Entry(newData).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
                    context.SaveChanges();
                    return newData;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_Gasto Actualizar(TMCCM_Gasto data)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    data.TB_Eliminado = false;
                    context.Entry(data).State = EntityState.Modified;
                    context.SaveChanges();
                    context.Entry(data).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
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
                    TMCCM_Gasto data = context.TMCCM_Gasto.Find(id);
                    data.TB_Eliminado = true;
                    context.Entry(data).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public IEnumerable<TMCCM_C_Gasto_Tipo_Gasto> ListarTipoGasto()
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    return context.TMCCM_C_Gasto_Tipo_Gasto
                        .Where(e => e.TB_Eliminado == false)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        }

        public TMCCM_C_Gasto_Tipo_Gasto InsertarTipo_Gasto(TMCCM_C_Gasto_Tipo_Gasto data) {
            try
            {
                using (var context = new MCCMEntities())
                {
                    data.TB_Eliminado = false;
                    TMCCM_C_Gasto_Tipo_Gasto newData = context.TMCCM_C_Gasto_Tipo_Gasto.Add(data);
                    context.SaveChanges();
                    return newData;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.Handle(e);
            }
        } 
    }
}
