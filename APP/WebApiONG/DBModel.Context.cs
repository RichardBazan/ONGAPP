﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiONG
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDONGEntities : DbContext
    {
        public BDONGEntities()
            : base("name=BDONGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Raza> Raza { get; set; }
        public virtual DbSet<Adopcion> Adopcion { get; set; }
        public virtual DbSet<CasaRefugio> CasaRefugio { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<DarAdopcion> DarAdopcion { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Donaciones> Donaciones { get; set; }
        public virtual DbSet<Foto_CasaRefugio> Foto_CasaRefugio { get; set; }
        public virtual DbSet<Foto_Denuncia> Foto_Denuncia { get; set; }
        public virtual DbSet<Foto_Mascota> Foto_Mascota { get; set; }
        public virtual DbSet<Like_Comentario> Like_Comentario { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
