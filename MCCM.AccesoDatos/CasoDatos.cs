using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class CasoDatos
    {
        public void InsertarCaso(TMCCM_Caso caso)
        {
            using (var context = new MCCMEntities())
            {
                caso.TB_Eliminado = true;
                caso.TF_Fecha = DateTime.Now;
                context.TMCCM_Caso.Add(caso);
                context.SaveChanges();
            }
        }

        public void ActualizarCaso(TMCCM_Caso caso)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Caso.SingleOrDefault(b => b.TN_ID_Caso == caso.TN_ID_Caso);
                if (result != null)
                {
                    result.TC_Area_Trabajo = caso.TC_Area_Trabajo;
                    result.TC_Delito = caso.TC_Delito;
                    result.TC_Descripcion = caso.TC_Descripcion;
                    result.TC_Enfoque_Trabajo = caso.TC_Enfoque_Trabajo;
                    result.TC_Fuente = caso.TC_Fuente;
                    result.TC_Nombre_Caso = caso.TC_Nombre_Caso;
                    result.TN_ECU = caso.TN_ECU;
                    result.TN_Nivel = caso.TN_Nivel;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarCaso(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Caso.SingleOrDefault(b => b.TN_ID_Caso == ID);
                if (result != null)
                {
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }




        public List<TMCCM_CasoDTO> ListarCasos()
        {
            List<TMCCM_CasoDTO> casosDTO = null;

            using (var context = new MCCMEntities())
            {
                casosDTO = context.TMCCM_Caso.Where(c => c.TB_Eliminado==true)
                  .Select(casoItem => new TMCCM_CasoDTO()
                  {
                      TN_ID_Caso = casoItem.TN_ID_Caso,
                      TC_Nombre_Caso = casoItem.TC_Nombre_Caso,
                      TC_Delito = casoItem.TC_Delito,
                      TF_Fecha = casoItem.TF_Fecha
                  }).ToList<TMCCM_CasoDTO>();
            }

            return casosDTO;
        }

        public TMCCM_CasoDTO ObtenerCasoPorID(int ID)
        {
            TMCCM_CasoDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from casoItem in context.TMCCM_Caso
                       select new TMCCM_CasoDTO(){
                    TN_ID_Caso = casoItem.TN_ID_Caso,
                    TC_Nombre_Caso = casoItem.TC_Nombre_Caso,
                    TC_Delito = casoItem.TC_Delito,
                    TF_Fecha = casoItem.TF_Fecha,
                    TC_Area_Trabajo=casoItem.TC_Area_Trabajo,
                    TC_Fuente=casoItem.TC_Fuente,
                    TN_ECU=casoItem.TN_ECU,
                    TN_Nivel=casoItem.TN_Nivel,
                    TC_Descripcion=casoItem.TC_Descripcion,
                    TC_Enfoque_Trabajo=casoItem.TC_Enfoque_Trabajo
                }).Where(x => x.TN_ID_Caso == ID).Single(); 
            }
            return aux;
        }

    }



}
