using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    class TMCCM_UsuarioDTO
    {
        public int TN_ID_Usuario { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Primer_Apellido { get; set; }
        public string TC_Segundo_Apellido { get; set; }
        public string TC_Contrasennia { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public string TC_Identificacion { get; set; }
        public string TC_Correo { get; set; }
    }
}
