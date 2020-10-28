﻿using MCCM.Entidad;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class VehiculoDatos
    {
        public IEnumerable<TMCCM_Vehiculo> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Vehiculo.Where(e => e.TB_Eliminado == true).ToList();
            }
        }

        public TMCCM_Vehiculo ObtenerPorId(int id)
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Vehiculo.Find(id);
            }
        }


        public TMCCM_Vehiculo Insertar(TMCCM_Vehiculo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                TMCCM_Vehiculo newData = context.TMCCM_Vehiculo.Add(data);
                context.SaveChanges();
                return newData;
            }
        }

        public TMCCM_Vehiculo Actualizar(TMCCM_Vehiculo data)
        {
            using (var context = new MCCMEntities())
            {
                data.TB_Eliminado = true;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
                return data;
            }
        }

        public void EliminarPorId(int id)
        {
            using (var context = new MCCMEntities())
            {
                TMCCM_Vehiculo data = context.TMCCM_Vehiculo.Find(id);
                data.TB_Eliminado = false;
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
