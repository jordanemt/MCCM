//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCCM.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class TMCCM_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMCCM_Usuario()
        {
            this.TMCCM_Grupo_Usuario = new HashSet<TMCCM_Grupo_Usuario>();
            this.TMCCM_Tarea = new HashSet<TMCCM_Tarea>();
            this.TMCCM_Rol = new HashSet<TMCCM_Rol>();
        }
    
        public int TN_ID_Usuario { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Primer_Apellido { get; set; }
        public string TC_Segundo_Apellido { get; set; }
        public string TC_Contrasennia { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
        public string TC_Identificacion { get; set; }
        public string TC_Correo { get; set; }
        public Nullable<bool> TB_En_Grupo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Grupo_Usuario> TMCCM_Grupo_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Tarea> TMCCM_Tarea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TMCCM_Rol> TMCCM_Rol { get; set; }
    }
}
