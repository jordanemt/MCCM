﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual DbSet<TMCCM_C_Arma_Marca> TMCCM_C_Arma_Marca { get; set; }
        public virtual DbSet<TMCCM_C_Arma_Tipo_Arma> TMCCM_C_Arma_Tipo_Arma { get; set; }
        public virtual DbSet<TMCCM_C_Droga_Tipo_Droga> TMCCM_C_Droga_Tipo_Droga { get; set; }
        public virtual DbSet<TMCCM_C_Gasto_Tipo_Gasto> TMCCM_C_Gasto_Tipo_Gasto { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Genero> TMCCM_C_Persona_Genero { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Juridica_Tipo_Organizacion> TMCCM_C_Persona_Juridica_Tipo_Organizacion { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Nacionalidad> TMCCM_C_Persona_Nacionalidad { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Sexo> TMCCM_C_Persona_Sexo { get; set; }
        public virtual DbSet<TMCCM_C_Persona_Tipo_Identificacion> TMCCM_C_Persona_Tipo_Identificacion { get; set; }
        public virtual DbSet<TMCCM_C_Telefono_Empresa_Telefonica> TMCCM_C_Telefono_Empresa_Telefonica { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Canton> TMCCM_C_Ubicacion_Canton { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Distrito> TMCCM_C_Ubicacion_Distrito { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Provincia> TMCCM_C_Ubicacion_Provincia { get; set; }
        public virtual DbSet<TMCCM_C_Ubicacion_Tipo_Ubicacion> TMCCM_C_Ubicacion_Tipo_Ubicacion { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Clase> TMCCM_C_Vehiculo_Clase { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Color> TMCCM_C_Vehiculo_Color { get; set; }
        public virtual DbSet<TMCCM_C_Vehiculo_Marca> TMCCM_C_Vehiculo_Marca { get; set; }
        public virtual DbSet<TMCCM_Caso> TMCCM_Caso { get; set; }
        public virtual DbSet<TMCCM_Entidad_Arma> TMCCM_Entidad_Arma { get; set; }
        public virtual DbSet<TMCCM_Entidad_Droga> TMCCM_Entidad_Droga { get; set; }
        public virtual DbSet<TMCCM_Entidad_Persona> TMCCM_Entidad_Persona { get; set; }
        public virtual DbSet<TMCCM_Entidad_Persona_Juridica> TMCCM_Entidad_Persona_Juridica { get; set; }
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
    
        public virtual ObjectResult<sp_Obtener_Catalogo_Usuario_Result> sp_Obtener_Catalogo_Usuario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Obtener_Catalogo_Usuario_Result>("sp_Obtener_Catalogo_Usuario");
        }
    
        public virtual ObjectResult<sp_obtenerEventosPorCaso_Result> sp_obtenerEventosPorCaso(Nullable<int> casoID)
        {
            var casoIDParameter = casoID.HasValue ?
                new ObjectParameter("casoID", casoID) :
                new ObjectParameter("casoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerEventosPorCaso_Result>("sp_obtenerEventosPorCaso", casoIDParameter);
        }
    
        public virtual ObjectResult<sp_obtenerTareaPorCaso_Result> sp_obtenerTareaPorCaso(Nullable<int> idCaso)
        {
            var idCasoParameter = idCaso.HasValue ?
                new ObjectParameter("idCaso", idCaso) :
                new ObjectParameter("idCaso", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerTareaPorCaso_Result>("sp_obtenerTareaPorCaso", idCasoParameter);
        }
    }
}
