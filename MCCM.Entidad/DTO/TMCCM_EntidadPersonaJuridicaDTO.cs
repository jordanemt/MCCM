using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadPersonaJuridicaDTO
    {
        public int TN_ID_Persona_Juridica { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public string TC_ID_Cedula_Juridica { get; set; }
        public string TC_Nombre_Organización { get; set; }
        public string TC_Nombre_Comercial { get; set; }
        public Nullable<int> TN_ID_Icono_Persona_Juridica { get; set; }
        public HttpPostedFileBase TB_Fotografia { get; set; }
        public string imgTemporal { get; set; }
        public Nullable<int> TN_ID_Tipo_Organizacion { get; set; }
        public string TC_Sitio_Web { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    }
}
