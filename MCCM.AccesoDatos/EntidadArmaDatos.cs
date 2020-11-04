using MCCM.Entidad;
using MCCM.Entidad.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class EntidadArmaDatos
    {
        Utilidades utilidades = new Utilidades();
        public void InsertarEntidadArma(TMCCM_Entidad_Arma entidadArma)
        {
            using (var context = new MCCMEntities())
            {
                entidadArma.TB_Eliminado = false;
                entidadArma.TF_Fecha_Creacion = DateTime.Now;
                context.TMCCM_Entidad_Arma.Add(entidadArma);
                context.SaveChanges();
            }
        }
        public void ActualizarEntidadArma(TMCCM_Entidad_Arma entidadArma)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Arma.SingleOrDefault(b => b.TN_ID_Arma == entidadArma.TN_ID_Arma);
                if (result != null)
                {
                    result.TN_ID_Arma = entidadArma.TN_ID_Arma;
                    result.TN_ID_Marca_Arma = entidadArma.TN_ID_Marca_Arma;
                    result.TN_ID_Tipo_Arma = entidadArma.TN_ID_Tipo_Arma;
                    result.TC_Modelo_Arma = entidadArma.TC_Modelo_Arma;
                    result.TC_Calibre = entidadArma.TC_Calibre;
                    result.TC_Serie = entidadArma.TC_Serie;
                    result.TC_Comentario = entidadArma.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadArma.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = DateTime.Now; ;
                    result.TC_Creado_Por = entidadArma.TC_Creado_Por;
                    result.TC_Modificado_Por = entidadArma.TC_Modificado_Por;
                    result.TB_Verificado = entidadArma.TB_Verificado;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EliminarEntidadArma(int ID)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Arma.SingleOrDefault(b => b.TN_ID_Arma == ID);
                if (result != null)
                {
                    result.TB_Eliminado = true;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public string ListarEntidadArmas(int caso)
        {
            using (var context = new MCCMEntities())
            {
                var anonimo= from armaItem in context.TMCCM_Entidad_Arma
                             from marcaItem in context.TMCCM_C_Arma_Marca
                             from tipoItem in context.TMCCM_C_Arma_Tipo_Arma
                             where armaItem.TB_Eliminado == false
                             where armaItem.TN_ID_Caso == caso
                             where armaItem.TN_ID_Marca_Arma == marcaItem.TN_ID_Marca_Arma
                             where armaItem.TN_ID_Tipo_Arma == tipoItem.TN_ID_Tipo_Arma
                             select new 
                   {
                       TN_ID_Arma = armaItem.TN_ID_Arma,
                       TN_ID_Marca_Arma = armaItem.TN_ID_Marca_Arma,
                       TC_Marca = marcaItem.TC_Descripcion,
                       TC_Tipo = tipoItem.TC_Descripcion,
                       TC_Calibre = armaItem.TC_Calibre
                   };
           
            return JsonConvert.SerializeObject(anonimo, Formatting.Indented); 
            }
        }

        public String ObtenerEntidadArmaPorID(int ID)
        {
            
            using (var context = new MCCMEntities())
            {
                var anonimo = (from armaItem in context.TMCCM_Entidad_Arma
                              where armaItem.TB_Eliminado == false
                              where armaItem.TN_ID_Arma == ID
                              select new
                              {
                                  TN_ID_Arma = armaItem.TN_ID_Arma,
                               TN_ID_Caso = armaItem.TN_ID_Caso,
                               TN_ID_Marca_Arma = armaItem.TN_ID_Marca_Arma,
                               TN_ID_Tipo_Arma = armaItem.TN_ID_Tipo_Arma,
                               TC_Modelo_Arma = armaItem.TC_Modelo_Arma,
                               TC_Calibre = armaItem.TC_Calibre,
                               TC_Serie = armaItem.TC_Serie,
                               TC_Comentario = armaItem.TC_Comentario,
                               TF_Fecha_Creacion = armaItem.TF_Fecha_Creacion,
                               TF_Fecha_Modificacion = armaItem.TF_Fecha_Modificacion,
                               TC_Creado_Por = armaItem.TC_Creado_Por,
                               TC_Modificado_Por = armaItem.TC_Modificado_Por,
                               TB_Verificado = armaItem.TB_Verificado,
                       }).Single();
           
            return JsonConvert.SerializeObject(anonimo, Formatting.Indented);
            }
        }
    }
}

