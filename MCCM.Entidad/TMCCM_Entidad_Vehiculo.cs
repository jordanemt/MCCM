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
    
    public partial class TMCCM_Entidad_Vehiculo
    {
        public int TN_ID_Vehiculo { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Marca_Vehiculo { get; set; }
        public Nullable<int> TN_ID_Color_Vehiculo { get; set; }
        public string TC_Placa { get; set; }
        public string TC_Estilo { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<int> TN_Anno { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public byte[] TB_Fotografia { get; set; }
        public Nullable<int> TN_ID_Clase_Vehiculo { get; set; }
    
        public virtual TMCCM_C_Vehiculo_Clase TMCCM_C_Vehiculo_Clase { get; set; }
        public virtual TMCCM_C_Vehiculo_Color TMCCM_C_Vehiculo_Color { get; set; }
        public virtual TMCCM_C_Vehiculo_Marca TMCCM_C_Vehiculo_Marca { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
