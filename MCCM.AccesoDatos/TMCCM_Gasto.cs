//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCCM.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TMCCM_Gasto
    {
        public int TN_ID_Gasto { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Tipo_Gasto { get; set; }
        public Nullable<System.DateTime> TF_Fecha { get; set; }
        public Nullable<int> TN_Num_Factura { get; set; }
        public Nullable<float> TD_Monto { get; set; }
        public string TC_Compra { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        public virtual TMCCM_C_Gasto_Tipo_Gasto TMCCM_C_Gasto_Tipo_Gasto { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
