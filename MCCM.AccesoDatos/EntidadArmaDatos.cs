using MCCM.Entidad;
using MCCM.Entidad.DTO;
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
        public void InsertarEntidadArma(TMCCM_EntidadArmaDTO entidadArmaDTO)
        {
            using (var context = new MCCMEntities())
            {
                context.TMCCM_Entidad_Arma.Add(new TMCCM_Entidad_Arma()
                {
                    TN_ID_Caso = entidadArmaDTO.TN_ID_Caso,
                    TN_ID_Marca_Arma = entidadArmaDTO.TN_ID_Marca_Arma,
                    TN_ID_Icono_Arma = entidadArmaDTO.TN_ID_Icono_Arma,
                    TN_ID_Tipo_Arma = entidadArmaDTO.TN_ID_Tipo_Arma,
                    TC_Modelo_Arma = entidadArmaDTO.TC_Modelo_Arma,
                    TC_Calibre = entidadArmaDTO.TC_Calibre,
                    TC_Serie = entidadArmaDTO.TC_Serie,
                    TC_Comentario = entidadArmaDTO.TC_Comentario,
                    TF_Fecha_Creacion = entidadArmaDTO.TF_Fecha_Creacion,
                    TF_Fecha_Modificacion = entidadArmaDTO.TF_Fecha_Modificacion,
                    TC_Creado_Por = entidadArmaDTO.TC_Creado_Por,
                    TC_Modificado_Por = "",
                    TB_Verificado = entidadArmaDTO.TB_Verificado,
                });

                context.SaveChanges();
            }
        }
        public void ActualizarEntidadArma(TMCCM_EntidadArmaDTO entidadArmaDTO)
        {
            using (var context = new MCCMEntities())
            {
                var result = context.TMCCM_Entidad_Arma.SingleOrDefault(b => b.TN_ID_Arma == entidadArmaDTO.TN_ID_Arma);
                if (result != null)
                {
                    result.TN_ID_Arma = entidadArmaDTO.TN_ID_Arma;
                    result.TN_ID_Caso = entidadArmaDTO.TN_ID_Caso;
                    result.TN_ID_Marca_Arma = entidadArmaDTO.TN_ID_Marca_Arma;
                    result.TN_ID_Icono_Arma = entidadArmaDTO.TN_ID_Icono_Arma;
                    result.TN_ID_Tipo_Arma = entidadArmaDTO.TN_ID_Tipo_Arma;
                    result.TC_Modelo_Arma = entidadArmaDTO.TC_Modelo_Arma;
                    result.TC_Calibre = entidadArmaDTO.TC_Calibre;
                    result.TC_Serie = entidadArmaDTO.TC_Serie;
                    result.TC_Comentario = entidadArmaDTO.TC_Comentario;
                    result.TF_Fecha_Creacion = entidadArmaDTO.TF_Fecha_Creacion;
                    result.TF_Fecha_Modificacion = entidadArmaDTO.TF_Fecha_Modificacion;
                    result.TC_Creado_Por = entidadArmaDTO.TC_Creado_Por;
                    result.TC_Modificado_Por = "";
                    result.TB_Verificado = entidadArmaDTO.TB_Verificado;
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
                    result.TB_Eliminado = false;
                    context.Entry(result).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public List<TMCCM_EntidadArmaDTO> ListarEntidadArmas()
        {
            List<TMCCM_EntidadArmaDTO> entidadArmaDTO = null;

            using (var context = new MCCMEntities())
            {
                entidadArmaDTO = context.TMCCM_Entidad_Arma.Where(c => c.TB_Eliminado == true)
                   .Select(armaItem => new TMCCM_EntidadArmaDTO()
                   {
                       TN_ID_Arma = armaItem.TN_ID_Arma,
                       TN_ID_Caso = armaItem.TN_ID_Caso,
                       TN_ID_Marca_Arma = armaItem.TN_ID_Marca_Arma,
                       TN_ID_Icono_Arma = armaItem.TN_ID_Icono_Arma,
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
                   }).ToList<TMCCM_EntidadArmaDTO>();
            }
            return entidadArmaDTO;
        }

        public TMCCM_EntidadArmaDTO ObtenerEntidadArmaPorID(int ID)
        {
            TMCCM_EntidadArmaDTO aux;
            using (var context = new MCCMEntities())
            {
                aux = (from armaItem in context.TMCCM_Entidad_Arma
                       select new TMCCM_EntidadArmaDTO()
                       {
                           TN_ID_Arma = armaItem.TN_ID_Arma,
                           TN_ID_Caso = armaItem.TN_ID_Caso,
                           TN_ID_Marca_Arma = armaItem.TN_ID_Marca_Arma,
                           TN_ID_Icono_Arma = armaItem.TN_ID_Icono_Arma,
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
                       }).Where(x => x.TN_ID_Arma == ID).Single();
            }
            return aux;
        }
    }
}

