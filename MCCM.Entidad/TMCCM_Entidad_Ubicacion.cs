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
    
    public partial class TMCCM_Entidad_Ubicacion
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
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
    
        public virtual TMCCM_C_Ubicacion_Canton TMCCM_C_Ubicacion_Canton { get; set; }
        public virtual TMCCM_C_Ubicacion_Distrito TMCCM_C_Ubicacion_Distrito { get; set; }
        public virtual TMCCM_C_Ubicacion_Provincia TMCCM_C_Ubicacion_Provincia { get; set; }
        public virtual TMCCM_C_Ubicacion_Tipo_Ubicacion TMCCM_C_Ubicacion_Tipo_Ubicacion { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
