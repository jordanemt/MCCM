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
    
    public partial class TMCCM_Grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_Grupo()
        {
            this.TMCCM_Grupo_Usuario = new HashSet<TMCCM_Grupo_Usuario>();
            this.TMCCM_Grupo_Vehiculo = new HashSet<TMCCM_Grupo_Vehiculo>();
        }
    
        public int TN_ID_Grupo { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<System.TimeSpan> TF_Hora { get; set; }
        public string TC_Zona { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Inicio { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Final { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public Nullable<bool> TB_Mando { get; set; }
    
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Grupo_Usuario> TMCCM_Grupo_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Grupo_Vehiculo> TMCCM_Grupo_Vehiculo { get; set; }
    }
}
