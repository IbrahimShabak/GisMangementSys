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
    
    public partial class OrganizationsProject
    {
        public int SerNum { get; set; }
        public Nullable<int> PeopleID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> OrgTypeID { get; set; }
    
        public virtual OegType OegType { get; set; }
        public virtual PepoleTBL PepoleTBL { get; set; }
        public virtual ProjectTBL ProjectTBL { get; set; }
    }
}
