﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.Bussiness
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhanMemCanXeTaiEntities1 : DbContext
    {
        public PhanMemCanXeTaiEntities1()
            : base("name=PhanMemCanXeTaiEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PhieuCan> PhieuCan { get; set; }
    }
}