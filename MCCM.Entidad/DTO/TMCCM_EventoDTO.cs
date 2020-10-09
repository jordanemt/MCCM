using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EventoDTO
    {
        public int TN_ID_Evento { get; set; }
        public Nullable<System.DateTime> TF_Fecha { get; set; }
        public Nullable<System.TimeSpan> TF_Hora { get; set; }
        public string TC_Informa { get; set; }
        public string TC_Lugar { get; set; }
        public string TC_Novedad { get; set; }

    }
}
