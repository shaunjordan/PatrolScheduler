//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CapstonePatrol
    {
        public int PatrolId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> PatrolStart { get; set; }
        public Nullable<System.DateTime> PatrolEnd { get; set; }
    
        public virtual CapstoneCustomer CapstoneCustomer { get; set; }
        public virtual CapstoneEmployee CapstoneEmployee { get; set; }
    }
}
