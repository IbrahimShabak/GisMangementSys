//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities.Archive
{
    using System;
    
    public partial class GetAllArchiveTBL_Result
    {
        public int ID { get; set; }
        public string Details { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> DocumentType { get; set; }
        public string FilePathLink { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<bool> WithHardCopy { get; set; }
    }
}
