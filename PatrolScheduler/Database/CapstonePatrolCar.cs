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
    
    public partial class CapstonePatrolCar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapstonePatrolCar()
        {
            this.CapstoneGuard = new HashSet<CapstoneGuard>();
        }
    
        public int CarId { get; set; }
        public string VIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CapstoneGuard> CapstoneGuard { get; set; }
    }
}
