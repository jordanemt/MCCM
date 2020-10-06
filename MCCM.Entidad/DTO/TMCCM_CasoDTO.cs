using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_CasoDTO
    {
        

        public int TN_ID_Caso { get; set; }
        public Nullable<int> TN_ECU { get; set; }
        public string TC_Nombre_Caso { get; set; }
        public string TC_Enfoque_Trabajo { get; set; }
        public string TC_Area_Trabajo { get; set; }
        public Nullable<int> TN_Nivel { get; set; }
        public string TC_Descripcion { get; set; }
        public string TC_Fuente { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public string TC_Delito { get; set; }
        public Nullable<System.DateTime> TF_Fecha { get; set; }
    
    
    }
}
