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
    
    public partial class TMCCM_C_Droga_Tipo_Droga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_C_Droga_Tipo_Droga()
        {
            this.TMCCM_Entidad_Droga = new HashSet<TMCCM_Entidad_Droga>();
        }
    
        public int TN_ID_Tipo_Droga { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Entidad_Droga> TMCCM_Entidad_Droga { get; set; }
    }
}
