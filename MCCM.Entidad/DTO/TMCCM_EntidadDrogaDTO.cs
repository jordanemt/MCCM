using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadDrogaDTO
    {
        public int TN_ID_Droga { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Tipo_Droga { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Detalle { get; set; }
        public Nullable<int> TN_Cantidad { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Decomiso { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
    }
}
