﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatrolScheduler.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CapstoneDatabase : DbContext
    {
        public CapstoneDatabase()
            : base("name=CapstoneDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CapstoneCustomer> CapstoneCustomers { get; set; }
        public virtual DbSet<CapstoneEmployee> CapstoneEmployees { get; set; }
        public virtual DbSet<CapstonePatrol> CapstonePatrols { get; set; }
        public virtual DbSet<CapstonePatrolCar> CapstonePatrolCars { get; set; }
        public virtual DbSet<CapstoneUser> CapstoneUsers { get; set; }
    
        public virtual ObjectResult<CapstoneUser> GetUser(string uName, string pWord)
        {
            var uNameParameter = uName != null ?
                new ObjectParameter("uName", uName) :
                new ObjectParameter("uName", typeof(string));
    
            var pWordParameter = pWord != null ?
                new ObjectParameter("pWord", pWord) :
                new ObjectParameter("pWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CapstoneUser>("GetUser", uNameParameter, pWordParameter);
        }
    
        public virtual ObjectResult<CapstoneUser> GetUser(string uName, string pWord, MergeOption mergeOption)
        {
            var uNameParameter = uName != null ?
                new ObjectParameter("uName", uName) :
                new ObjectParameter("uName", typeof(string));
    
            var pWordParameter = pWord != null ?
                new ObjectParameter("pWord", pWord) :
                new ObjectParameter("pWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CapstoneUser>("GetUser", mergeOption, uNameParameter, pWordParameter);
        }
    }
}