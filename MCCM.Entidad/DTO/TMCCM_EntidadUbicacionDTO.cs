using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadUbicacionDTO
    {
        public int TN_ID_Ubicacion { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Tipo_Ubicacion { get; set; }
        public Nullable<int> TN_ID_Provincia { get; set; }
        public Nullable<int> TN_ID_Canton { get; set; }
        public Nullable<int> TN_ID_Distrito { get; set; }
        public string TC_Sennas { get; set; }
        public Nullable<double> TD_Latitud { get; set; }
        public Nullable<double> TD_Longitud { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
    }
}
