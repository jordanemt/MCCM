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
    
    public partial class TMCCM_C_Ubicacion_Canton
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_C_Ubicacion_Canton()
        {
            this.TMCCM_C_Ubicacion_Distrito = new HashSet<TMCCM_C_Ubicacion_Distrito>();
            this.TMCCM_Entidad_Ubicacion = new HashSet<TMCCM_Entidad_Ubicacion>();
        }
    
        public int TN_ID_Canton { get; set; }
        public Nullable<int> TN_ID_Provincia { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_C_Ubicacion_Distrito> TMCCM_C_Ubicacion_Distrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Entidad_Ubicacion> TMCCM_Entidad_Ubicacion { get; set; }
        public virtual TMCCM_C_Ubicacion_Provincia TMCCM_C_Ubicacion_Provincia { get; set; }
    }
}