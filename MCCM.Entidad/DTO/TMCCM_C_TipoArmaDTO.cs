using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_C_TipoArmaDTO
    {
        public int TN_ID_Tipo_Arma { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<int> TN_Peso { get; set; }

    }
}
