//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities.Fininchal
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceType()
        {
            this.InvoicesTBLs = new HashSet<InvoicesTBL>();
        }
    
        public int TypeID { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicesTBL> InvoicesTBLs { get; set; }
    }
}
