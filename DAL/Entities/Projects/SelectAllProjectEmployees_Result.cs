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
    
    public partial class SelectAllProjectEmployees_Result
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int EmpID { get; set; }
        public Nullable<System.DateTime> StartFrom { get; set; }
        public Nullable<System.DateTime> EndTo { get; set; }
        public int PositionInProject { get; set; }
    }
}
