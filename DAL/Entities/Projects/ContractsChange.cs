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
    
    public partial class ContractsChange
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string ChangedDescription { get; set; }
        public Nullable<decimal> OriginalAmount { get; set; }
        public Nullable<decimal> NewAmount { get; set; }
    
        public virtual ProjectTBL ProjectTBL { get; set; }
    }
}
