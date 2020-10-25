using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_C_UbicacionCantonDTO
    {
        public int TN_ID_Canton { get; set; }
        public Nullable<int> TN_ID_Provincia { get; set; }
        public string TC_Descripcion { get; set; }
    }
}
