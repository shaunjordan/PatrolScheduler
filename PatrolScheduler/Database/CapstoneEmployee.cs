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
    
    public partial class CapstoneEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapstoneEmployee()
        {
            this.CapstonePatrols = new HashSet<CapstonePatrol>();
        }
    
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<int> BadgeNumber { get; set; }
        public Nullable<int> PatrolCar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CapstonePatrol> CapstonePatrols { get; set; }
    }
}
