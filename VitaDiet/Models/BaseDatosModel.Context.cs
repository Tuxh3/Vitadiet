﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VitaDiet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VITADIETEntities : DbContext
    {
        public VITADIETEntities()
            : base("name=VITADIETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DIETA> DIETA { get; set; }
        public virtual DbSet<HISTORIAL> HISTORIAL { get; set; }
        public virtual DbSet<NUTRICIONISTA> NUTRICIONISTA { get; set; }
        public virtual DbSet<PACIENTE> PACIENTE { get; set; }
        public virtual DbSet<PQR> PQR { get; set; }
        public virtual DbSet<RUTA> RUTA { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<DISTRIBUIDOR> DISTRIBUIDOR { get; set; }

        public System.Data.Entity.DbSet<VitaDiet.Models.PacienteUser> PacienteUsers { get; set; }
    }
}