﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoodPlaysEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoodPlaysEntities : DbContext
    {
        public GoodPlaysEntities()
            : base("name=GoodPlaysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ListItem> ListItems { get; set; }
        public virtual DbSet<ListType> ListTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
