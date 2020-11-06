using MCCM.AccesoDatos.exceptions;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCCM.AccesoDatos
{
    public class VehiculoDatos
    {
        public IEnumerable<TMCCM_Vehiculo> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Vehiculo.Where(e => e.TB_Eliminado == false && e.TB_En_Uso == false).ToList();
            }
        }

        public TMCCM_Vehiculo Insertar(TMCCM_Vehiculo data)
        {
            try
            {
                using (var context = new MCCMEntities())
                {
                    if (context.TMCCM_Vehiculo.Where(e => e.TB_Eliminado == false && e.TC_Placa == data.TC_Placa).FirstOrDefault() != null) {
                        throw new PlacaVehiculoException();
                    }
                    data.TB_Eliminado = false;
                    data.TB_En_Uso = false;
                    TMCCM_Vehiculo newData = context.TMCCM_Vehiculo.Add(data);
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
