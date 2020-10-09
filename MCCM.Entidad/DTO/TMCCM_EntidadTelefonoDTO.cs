using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadTelefonoDTO
    {
        public int TN_ID_Telefono { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Proveedor { get; set; }
        public Nullable<int> TN_ID_Icono_Telefono { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<int> TN_Numero { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
    }
}
