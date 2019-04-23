using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Employees;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Employee
{
    [DataContract]
    public class EmployeeTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الرقم الوظيفي")]
        [Key]
        public int EmployeeID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الأسم بالكامل")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Employee Full Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإلتحاق")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الميلاد")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> BithDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الجنسية")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> NationalityID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "القسم")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> DivisionID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المسمى الوظيفي")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> JobTitleID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الجوال")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string PhoneNumber { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "على رأس العمل")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<bool> IsActiveStatus { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "البريد الإلكتروني")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EmailAddress { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> OffDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "نوع الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> OffTypeID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static EmployeeTBLMapper Mapper = new EmployeeTBLMapper();
        public EmployeeTBL GetOriginal(EmployeeTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static EmployeeTBLDTO GetDTO(EmployeeTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class EmployeeTBLMapper : MapperBase<EmployeeTBL, EmployeeTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<EmployeeTBL, EmployeeTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<EmployeeTBL, EmployeeTBLDTO>>)(p => new EmployeeTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    EmployeeID = p.EmployeeID,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    StartDate = p.StartDate,
                    BithDate = p.BithDate,
                    NationalityID = p.NationalityID,
                    DivisionID = p.DivisionID,
                    JobTitleID = p.JobTitleID,
                    PhoneNumber = p.PhoneNumber,
                    IsActiveStatus = p.IsActiveStatus,
                    EmailAddress = p.EmailAddress,
                    OffDate = p.OffDate,
                    OffTypeID = p.OffTypeID
                }));
            }
        }

        public override void MapToModel(EmployeeTBLDTO dto, EmployeeTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.EmployeeID = dto.EmployeeID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;
            model.StartDate = dto.StartDate;
            model.BithDate = dto.BithDate;
            model.NationalityID = dto.NationalityID;
            model.DivisionID = dto.DivisionID;
            model.JobTitleID = dto.JobTitleID;
            model.PhoneNumber = dto.PhoneNumber;
            model.IsActiveStatus = dto.IsActiveStatus;
            model.EmailAddress = dto.EmailAddress;
            model.OffDate = dto.OffDate;
            model.OffTypeID = dto.OffTypeID;

        }
    }
}
