﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECTINVOICE.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class miniprojektEntities : DbContext
    {
        public miniprojektEntities()
            : base("name=miniprojektEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CostType> CostType { get; set; }
        public virtual DbSet<INVOICE> INVOICE { get; set; }
        public virtual DbSet<Property> Property { get; set; }
    }
}
