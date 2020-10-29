using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadArmaDTO
    {

        public int TN_ID_Arma { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Marca_Arma { get; set; }
        public Nullable<int> TN_ID_Icono_Arma { get; set; }
        public Nullable<int> TN_ID_Tipo_Arma { get; set; }
        public string TC_Modelo_Arma { get; set; }
        public string TC_Calibre { get; set; }
        public string TC_Serie { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public string TC_Comentario { get; set; }
    }
}
