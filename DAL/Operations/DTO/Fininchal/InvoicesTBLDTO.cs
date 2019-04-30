using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Fininchal;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Fininchal
{
    [DataContract]
    public class InvoicesTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int RecordID { get; set; }
        [DataMember]
        public string InvoicelID { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public string EnName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> InvoiceIssueDate { get; set; }
        [DataMember]
        public Nullable<int> InvoiceType { get; set; }
        [DataMember]
        public Nullable<bool> DeliveryStatus { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        [DataMember]
        public Nullable<decimal> InvoiceAmount { get; set; }
        [DataMember]
        public Nullable<bool> PaidStatus { get; set; }
        [DataMember]
        public Nullable<decimal> PaidAmount { get; set; }
        [DataMember]
        public string CopyLink { get; set; }
        [DataMember]
        public Nullable<int> ProjectID { get; set; }
        [DataMember]
        public Nullable<int> EmpID { get; set; }
    }

    public class InvoicesTBLMapper : MapperBase<InvoicesTBL, InvoicesTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<InvoicesTBL, InvoicesTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<InvoicesTBL, InvoicesTBLDTO>>)(p => new InvoicesTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    RecordID = p.RecordID,
                    InvoicelID = p.InvoicelID,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    InvoiceIssueDate = p.InvoiceIssueDate,
                    InvoiceType = p.InvoiceType,
                    DeliveryStatus = p.DeliveryStatus,
                    DeliveryDate = p.DeliveryDate,
                    InvoiceAmount = p.InvoiceAmount,
                    PaidStatus = p.PaidStatus,
                    PaidAmount = p.PaidAmount,
                    CopyLink = p.CopyLink,
                    ProjectID = p.ProjectID,
                    EmpID = p.EmpID
                }));
            }
        }

        public override void MapToModel(InvoicesTBLDTO dto, InvoicesTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.RecordID = dto.RecordID;
            model.InvoicelID = dto.InvoicelID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;
            model.InvoiceIssueDate = dto.InvoiceIssueDate;
            model.InvoiceType = dto.InvoiceType;
            model.DeliveryStatus = dto.DeliveryStatus;
            model.DeliveryDate = dto.DeliveryDate;
            model.InvoiceAmount = dto.InvoiceAmount;
            model.PaidStatus = dto.PaidStatus;
            model.PaidAmount = dto.PaidAmount;
            model.CopyLink = dto.CopyLink;
            model.ProjectID = dto.ProjectID;
            model.EmpID = dto.EmpID;

        }
    }
}
