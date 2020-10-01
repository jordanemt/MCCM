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
    
    public partial class TMCCM_Entidad_Persona
    {
        public int TN_ID_Persona { get; set; }
        public Nullable<int> TN_ID_Caso { get; set; }
        public Nullable<int> TN_ID_Tipo_Identificacion { get; set; }
        public Nullable<int> TN_ID_Icono_Persona { get; set; }
        public Nullable<int> TN_ID_Sexo { get; set; }
        public Nullable<int> TN_ID_Genero { get; set; }
        public Nullable<int> TN_ID_Nacionalidad { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Primer_Apellido { get; set; }
        public string TC_Segundo_Apellido { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Nacimiento { get; set; }
        public Nullable<int> TN_Edad { get; set; }
        public byte[] TB_Fotografia { get; set; }
        public string TC_Cedula { get; set; }
        public Nullable<bool> TB_Fallecido { get; set; }
        public Nullable<int> TN_Autopsia { get; set; }
        public Nullable<bool> TB_Exp_Criminal { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Modificacion { get; set; }
        public string TC_Creado_Por { get; set; }
        public string TC_Modificado_Por { get; set; }
        public Nullable<bool> TB_Verificado { get; set; }
    
        public virtual TMCCM_C_Persona_Genero TMCCM_C_Persona_Genero { get; set; }
        public virtual TMCCM_C_Persona_Icono_Persona TMCCM_C_Persona_Icono_Persona { get; set; }
        public virtual TMCCM_C_Persona_Nacionalidad TMCCM_C_Persona_Nacionalidad { get; set; }
        public virtual TMCCM_C_Persona_Sexo TMCCM_C_Persona_Sexo { get; set; }
        public virtual TMCCM_C_Persona_Tipo_Identificacion TMCCM_C_Persona_Tipo_Identificacion { get; set; }
        public virtual TMCCM_Caso TMCCM_Caso { get; set; }
    }
}
