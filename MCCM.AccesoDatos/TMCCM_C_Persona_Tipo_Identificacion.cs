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
    
    public partial class TMCCM_C_Persona_Tipo_Identificacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_C_Persona_Tipo_Identificacion()
        {
            this.TMCCM_Entidad_Persona = new HashSet<TMCCM_Entidad_Persona>();
        }
    
        public int TN_ID_Tipo_Identificacion { get; set; }
        public string TC_Descripcion { get; set; }
        public string TC_Mascara { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Entidad_Persona> TMCCM_Entidad_Persona { get; set; }
    }
}
