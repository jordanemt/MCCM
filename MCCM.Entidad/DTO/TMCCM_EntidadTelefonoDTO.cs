using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadTelefonoDTO
    {


        public Nullable<int> TN_ID_Telefono { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Proveedor { get; set; }
        public Nullable<int> TN_ID_Icono_Telefono { get; set; }
        public string TC_Comentario_Telefono { get; set; }
        public Nullable<int> TN_Numero_Telefono { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion_Telefono { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion_Telefono { get; set; }
        public string TC_Creado_Por_Telefono { get; set; }
        public string TC_Modificado_Por_Telefono { get; set; }
        public Nullable<bool> TB_Verificado_Telefono { get; set; }
    }
}
