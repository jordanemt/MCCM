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
    
    public partial class TMCCM_Grupo_Vehiculo
    {
        public int TN_ID_Vehiculo { get; set; }
        public int TN_ID_Grupo { get; set; }
        public Nullable<int> TN_Km_Inicio { get; set; }
        public Nullable<int> TN_Km_Regreso { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Hora { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        public virtual TMCCM_Grupo TMCCM_Grupo { get; set; }
        public virtual TMCCM_Vehiculo TMCCM_Vehiculo { get; set; }
    }
}
