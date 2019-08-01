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
    
    public partial class EmployeeTBL
    {
        public int EmployeeID { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> BithDate { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> DivisionID { get; set; }
        public Nullable<int> JobTitleID { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> IsActiveStatus { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> OffDate { get; set; }
        public Nullable<int> OffTypeID { get; set; }
        public Nullable<int> GroupID { get; set; }
    
        public virtual DivisionTBL DivisionTBL { get; set; }
        public virtual EmployeeOffType EmployeeOffType { get; set; }
        public virtual JobTitleTBL JobTitleTBL { get; set; }
        public virtual NationalityTBL NationalityTBL { get; set; }
        public virtual GROUP GROUP { get; set; }
    }
}
