//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCCM.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class TMCCM_Tarea
    {
        public int TN_ID_Tarea { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Usuario { get; set; }
        public Nullable<System.DateTime> TF_Fecha { get; set; }
        public string TC_Diligencia { get; set; }
        public string TC_Lugar { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<int> TN_Tipo { get; set; }
    
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
        public virtual TMCCM_Usuario TMCCM_Usuario { get; set; }
    }
}
