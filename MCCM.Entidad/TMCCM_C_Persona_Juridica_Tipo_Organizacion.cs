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
    
    public partial class TMCCM_C_Persona_Juridica_Tipo_Organizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_C_Persona_Juridica_Tipo_Organizacion()
        {
            this.TMCCM_Entidad_Persona_Juridica = new HashSet<TMCCM_Entidad_Persona_Juridica>();
        }
    
        public int TN_ID_Tipo_Organizacion { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Entidad_Persona_Juridica> TMCCM_Entidad_Persona_Juridica { get; set; }
    }
}
