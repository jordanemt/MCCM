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
    
    public partial class TMCCM_Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_Rol()
        {
            this.TMCCM_Usuario = new HashSet<TMCCM_Usuario>();
        }
    
        public int TN_ID_Rol { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Usuario> TMCCM_Usuario { get; set; }
    }
}
