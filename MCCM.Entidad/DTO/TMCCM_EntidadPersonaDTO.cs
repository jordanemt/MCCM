using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_EntidadPersonaDTO
    {
        public int TN_ID_Persona { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Tipo_Identificacion { get; set; }
        public Nullable<int> TN_ID_Icono_Persona { get; set; }
        public Nullable<int> TN_ID_Sexo { get; set; }
        public Nullable<int> TN_ID_Genero { get; set; }
        public Nullable<int> TN_ID_Nacionalidad { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Primer_Apellido { get; set; }
        public string TC_Segundo_Apellido { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Nacimiento { get; set; }
        public Nullable<int> TN_Edad { get; set; }
        public byte[] TB_Fotografia { get; set; }
        public string TC_Cedula { get; set; }
        public Nullable<bool> TB_Fallecido { get; set; }
        public Nullable<int> TN_Autopsia { get; set; }
        public Nullable<bool> TB_Exp_Criminal { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public string TC_Comentario { get; set; }
        public string TC_Alias { get; set; }

    }
}
