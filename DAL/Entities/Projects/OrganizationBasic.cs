//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities.Projects
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrganizationBasic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrganizationBasic()
        {
            this.PepoleTBLs = new HashSet<PepoleTBL>();
        }
    
        public int OrgID { get; set; }
        public string OrgArName { get; set; }
        public string OrgEnName { get; set; }
        public string LandLineNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PepoleTBL> PepoleTBLs { get; set; }
    }
}
