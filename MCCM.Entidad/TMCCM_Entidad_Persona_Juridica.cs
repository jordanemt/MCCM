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
    
    public partial class TMCCM_Entidad_Persona_Juridica
    {
        public int TN_ID_Persona_Juridica { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public string TC_ID_Cedula_Juridica { get; set; }
        public string TC_Nombre_Organizacion { get; set; }
        public string TC_Nombre_Comercial { get; set; }
        public Nullable<int> TN_ID_Tipo_Organizacion { get; set; }
        public string TC_Sitio_Web { get; set; }
        public string TC_Comentario { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }
    
        public virtual TMCCM_C_Persona_Juridica_Tipo_Organizacion TMCCM_C_Persona_Juridica_Tipo_Organizacion { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
