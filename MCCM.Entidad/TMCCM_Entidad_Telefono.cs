//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCCM.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class TMCCM_Entidad_Telefono
    {
        public int TN_ID_Telefono { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Proveedor { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<int> TN_Numero { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        public virtual TMCCM_C_Telefono_Empresa_Telefonica TMCCM_C_Telefono_Empresa_Telefonica { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
