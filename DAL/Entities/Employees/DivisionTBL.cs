//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities.Employees
{
    using System;
    using System.Collections.Generic;
    
    public partial class DivisionTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DivisionTBL()
        {
            this.EmployeeTBLs = new HashSet<EmployeeTBL>();
        }
    
        public int DivisionID { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTBL> EmployeeTBLs { get; set; }
    }
}
