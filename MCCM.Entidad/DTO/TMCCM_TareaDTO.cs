using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_TareaDTO
    {
        public int TN_ID_Tarea { get; set; }
        public Nullable<int> TN_ID_Usuario { get; set; }
        public Nullable<System.DateTime> TF_Fecha { get; set; }
        public Nullable<System.TimeSpan> TF_Hora { get; set; }
        public string TC_Diligencia { get; set; }
        public string TC_Lugar { get; set; }
    }
}
