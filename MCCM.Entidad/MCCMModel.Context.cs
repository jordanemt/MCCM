﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MCCMEntities : DbContext
    {
        public MCCMEntities()
            : base("name=MCCMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TMCCM_C_Arma_Icono_Arma> TMCCM_C_Arma_Icono_Arma { get; set; }
        public virtual DbSet<TMCCM_C_Arma_Marca> TMCCM_C_Arma_Marca { get; set; }
        public virtual DbSet<TMCCM_C_Arma_Tipo_Arma> TMCCM_C_Arma_Tipo_Arma { get; set; }
        public virtual DbSet<TMCCM_C_Droga_Tipo_Droga> TMCCM_C_Droga_Tipo_Droga { get; set; }
        public virtual DbSet<TMCCM_C_Gasto_Tipo_Gasto> TMCCM_C_Gasto_Tipo_Gasto { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Genero> TMCCM_C_Persona_Genero { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Icono_Persona> TMCCM_C_Persona_Icono_Persona { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Nacionalidad> TMCCM_C_Persona_Nacionalidad { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Sexo> TMCCM_C_Persona_Sexo { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Tipo_Identificacion> TMCCM_C_Persona_Tipo_Identificacion { get; set; }
        public virtual DbSet<TMCCM_C_Telefono_Empresa_Telefonica> TMCCM_C_Telefono_Empresa_Telefonica { get; set; }
        public virtual DbSet<TMCCM_C_Telefono_Icono_Telefono> TMCCM_C_Telefono_Icono_Telefono { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Canton> TMCCM_C_Ubicacion_Canton { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Distrito> TMCCM_C_Ubicacion_Distrito { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Provincia> TMCCM_C_Ubicacion_Provincia { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Tipo_Ubicacion> TMCCM_C_Ubicacion_Tipo_Ubicacion { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Color> TMCCM_C_Vehiculo_Color { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Icono> TMCCM_C_Vehiculo_Icono { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Marca> TMCCM_C_Vehiculo_Marca { get; set; }
        public virtual DbSet<TMCCM_Caso> TMCCM_Caso { get; set; }
        public virtual DbSet<TMCCM_Entidad_Arma> TMCCM_Entidad_Arma { get; set; }
        public virtual DbSet<TMCCM_Entidad_Droga> TMCCM_Entidad_Droga { get; set; }
        public virtual DbSet<TMCCM_Entidad_Persona> TMCCM_Entidad_Persona { get; set; }
        public virtual DbSet<TMCCM_Entidad_Telefono> TMCCM_Entidad_Telefono { get; set; }
        public virtual DbSet<TMCCM_Entidad_Ubicacion> TMCCM_Entidad_Ubicacion { get; set; }
        public virtual DbSet<TMCCM_Entidad_Vehiculo> TMCCM_Entidad_Vehiculo { get; set; }
        public virtual DbSet<TMCCM_Evento> TMCCM_Evento { get; set; }
        public virtual DbSet<TMCCM_Gasto> TMCCM_Gasto { get; set; }
        public virtual DbSet<TMCCM_Grupo> TMCCM_Grupo { get; set; }
        public virtual DbSet<TMCCM_Grupo_Usuario> TMCCM_Grupo_Usuario { get; set; }
        public virtual DbSet<TMCCM_Grupo_Vehiculo> TMCCM_Grupo_Vehiculo { get; set; }
        public virtual DbSet<TMCCM_Rol> TMCCM_Rol { get; set; }
        public virtual DbSet<TMCCM_Tarea> TMCCM_Tarea { get; set; }
        public virtual DbSet<TMCCM_Usuario> TMCCM_Usuario { get; set; }
        public virtual DbSet<TMCCM_Vehiculo> TMCCM_Vehiculo { get; set; }
    }
}
