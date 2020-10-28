using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadVehiculoDTO
    {
        public int TN_ID_Vehiculo { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Marca_Vehiculo { get; set; }
        public Nullable<int> TN_ID_Icono_Vehiculo { get; set; }
        public Nullable<int> TN_ID_Color_Vehiculo { get; set; }
        public string TC_Placa { get; set; }
        public string TC_Clase { get; set; }
        public string TC_Estilo { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<int> TN_Anno { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public HttpPostedFileBase TB_Fotografia { get; set; }
        public string imgTemporal { get; set; }
    }
}
