﻿using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class GastoDatos
    {
        public IEnumerable<TMCCM_Gasto> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Gasto
                    .Where(e => e.TB_Eliminado == true)
                    .Include(e => e.TMCCM_C_Gasto_Tipo_Gasto)
                    .ToList();
            }
        }

        public IEnumerable<TMCCM_Gasto> ListarPorCaso(int idCaso)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Gasto
                    .Where(e => e.TB_Eliminado == true && e.TN_ID_Caso == idCaso)
                    .ToList();
            }
        }

        public TMCCM_Gasto ObtenerPorId(int id)
        {
            using (var context = new MCCMEntities())
            {
                var data = context.TMCCM_Gasto.Find(id);
                context.Entry(data).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
                return data;
            }
        }


        public TMCCM_Gasto Insertar(TMCCM_Gasto data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                data.TF_Fecha = DateTime.Now;
                TMCCM_Gasto newData = context.TMCCM_Gasto.Add(data);
                context.Entry(newData).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
                context.SaveChanges();
                return newData;
            }
        }

        public TMCCM_Gasto Actualizar(TMCCM_Gasto data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                data.TF_Fecha = DateTime.Now;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(data).Reference(e => e.TMCCM_C_Gasto_Tipo_Gasto).Load();
                return context.Entry(data).Entity;
            }
        }

        public void EliminarPorId(int id)
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
