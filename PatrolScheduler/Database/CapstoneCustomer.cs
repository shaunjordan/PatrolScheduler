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
    
    public partial class CapstoneCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapstoneCustomer()
        {
            this.CapstonePatrol = new HashSet<CapstonePatrol>();
        }
    
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> AddressId { get; set; }
    
        public virtual CapstoneAddress CapstoneAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CapstonePatrol> CapstonePatrol { get; set; }
    }
}