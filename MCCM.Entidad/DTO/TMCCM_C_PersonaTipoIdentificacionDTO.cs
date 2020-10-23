using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
   public class TMCCM_C_PersonaTipoIdentificacionDTO
    {
        public int TN_ID_Tipo_Identificacion { get; set; }
        public string TC_Descripcion { get; set; }
        public string TC_Mascara { get; set; }

        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
    }
}
